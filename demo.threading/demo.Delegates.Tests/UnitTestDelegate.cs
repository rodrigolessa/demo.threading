using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace demo.Delegates.Tests
{
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

        [TestMethod]
        public void DoTest01()
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            DoWorkDelegate m = new DoWorkDelegate(DoWork);

            IAsyncResult ar = m.BeginInvoke(null, null);

            // Do more

            m.EndInvoke(ar);
        }
    }
}