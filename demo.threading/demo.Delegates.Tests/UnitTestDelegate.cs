using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace demo.Delegates.Tests
{
    /// <summary>
    /// Delegate test
    /// </summary>
    [TestClass]
    public class UnitTestDelegate
    {
        [TestMethod]
        public void DoWork()
        {
            Debug.WriteLine("Hello World");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        delegate void DoWorkDelegate();

        /// <summary>
        /// Delegates first test
        /// </summary>
        [TestMethod]
        public void DoTest01()
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            DoWorkDelegate m = new DoWorkDelegate(DoWork);

            IAsyncResult ar = m.BeginInvoke(null, null);

            // Do more

            m.EndInvoke(ar);
        }

        /// <summary>
        /// Begin/End Async test
        /// </summary>
        [TestMethod]
        public void DoTest02()
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            DoWorkDelegate m = new DoWorkDelegate(DoWork);

            AsyncCallback callback = new AsyncCallback(TheCallback);

            IAsyncResult ar = m.BeginInvoke(callback, m);

            // Do more

            // Only for tests results
            System.Threading.Thread.Sleep(4000);
        }

        /// <summary>
        /// WaitHandle - Signaling
        /// </summary>
        [TestMethod]
        public void DoTest03()
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            DoWorkDelegate m = new DoWorkDelegate(DoWork);

            AsyncCallback callback = new AsyncCallback(TheCallback);

            IAsyncResult ar = m.BeginInvoke(callback, m);

            // Do more

            // Only for tests results
            ar.AsyncWaitHandle.WaitOne();
        }

        public static void TheCallback(IAsyncResult ar)
        {
            var m = ar.AsyncState as DoWorkDelegate;
            m.EndInvoke(ar); // This is where you use try/catch
        }
    }
}
