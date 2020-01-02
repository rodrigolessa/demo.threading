using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Sending and receiving messages is a central characteristic of any NServiceBus system
/// </summary>
namespace learn.nServiceBus.ClientUI
{
    // More DDD like
    // Command names should also convey business intent. UpdateCustomerPropertyXYZ, while more specific than CustomerMessage isn't a good name for an command because it's focused only on the data manipulation rather than the business meaning behind it. MarkCustomerAsGold, or something else that is more business-oriented, is a better choice.
    public class DoSomething : ICommand
    {
        // When sending a message, the endpoint's serializer will serialize an instance of the DoSomething class and add that to the contents of the outgoing message that goes to the queue. On the other end, the receiving endpoint will deserialize the message back to an instance of the message class so that it can be used in code.

        public int Id { get; set; }
        public ChildClass ChildStuff { get; set; }
        public List<ChildClass> ListOfChildStuff { get; set; } = new List<ChildClass>();
    }

    // Also, do not embed logic within your message classes. Each message should contain only automatic properties and not computed properties or methods. It is a good practice to initialize collection properties as shown above, so that you never have to deal with a null collection.

    public class ChildClass
    {
        public string SomeProperty { get; set; }
    }

    // HACK: Messages are data contracts and as such, they are shared between multiple endpoints. Therefore you should not put the classes in the same assembly with the endpoints; they should live in a separate class library.

    // Message assemblies should be entirely self-contained, meaning they should contain only NServiceBus message types, and any supporting types required by the messages themselves.For example, if a message uses an enumeration type for one of its properties, that enumeration type should also be contained within the same message assembly.

    // ** It is technically possible to embed messages within the endpoint assembly, but those messages can't be exchanged with other endpoints. Some of our samples break this rule and embed the messages in the endpoint assembly in order to make the sample easier to understand. In this tutorial, we'll stick to keeping them in dedicated message assemblies.
}
