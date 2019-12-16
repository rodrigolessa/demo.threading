using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.nServiceBus.ClientUI
{
    class Program
    {
        // Configure an endpoint
        // We're ready to create a messaging endpoint. A messaging endpoint (or just endpoint) is a logical component capable of sending and receiving messages. An endpoint is hosted within a process, which in this case is a simple console application, but could be a web application or other .NET process.

        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            Console.Title = "ClientUI";

            // The EndpointConfiguration class is where we define all the settings that determine how our endpoint will operate. The single string parameter ClientUI is the endpoint name, which serves as the logical identity for our endpoint, and forms a naming convention by which other things will derive their names, such as the input queue where the endpoint will listen for messages to process.
            var endpointConfiguration = new EndpointConfiguration("ClientUI");

            // This setting defines the transport that NServiceBus will use to send and receive messages. We are using the LearningTransport, which is bundled in the NServiceBus core library as a starter transport for learning how to use NServiceBus without any additional dependencies. All other transports are provided using different NuGet packages.
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            // Provides support for sending messages over RabbitMQ using the RabbitMQ .NET Client.
            // var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            // transport.UseConventionalRoutingTopology();
            // The RabbitMQ transport requires a connection string to connect to the broker. See connection settings for options on how to provide the connection string.

            // Start the endpoint, keep it running until we press the Enter key, then shut it down.

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
