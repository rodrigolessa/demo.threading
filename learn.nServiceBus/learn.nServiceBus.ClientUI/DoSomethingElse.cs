using NServiceBus;

namespace learn.nServiceBus.ClientUI
{
    public class DoSomethingElse : ICommand
    {
        public int Id { get; set; }
        public ChildClass ChildStuff { get; set; }
        public List<ChildClass> ListOfChildStuff { get; set; } = new List<ChildClass>();
    }

    public class ChildClass
    {
        public string SomeProperty { get; set; }
    }
}