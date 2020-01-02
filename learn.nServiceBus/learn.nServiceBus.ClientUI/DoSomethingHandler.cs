using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.nServiceBus.ClientUI
{
    public class DoSomethingHandler : IHandleMessages<DoSomething>, IHandleMessages<DoSomethingElse>
    {
        // public async Task Handle(DoSomething message, IMessageHandlerContext context)
        // https://docs.particular.net/nservicebus/handlers/async-handlers
        public Task Handle(DoSomething message, IMessageHandlerContext context)
        {
            Console.WriteLine("Received DoSomething");
            return Task.CompletedTask;
        }

        public Task Handle(DoSomethingElse message, IMessageHandlerContext context)
        {
            Console.WriteLine("Received DoSomethingElse");
            return Task.CompletedTask;
        }
    }
}
