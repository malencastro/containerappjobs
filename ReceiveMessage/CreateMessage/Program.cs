using Azure.Messaging.ServiceBus;


namespace ConsoleApp1
{
    static class Program
    {

        static async Task Main(string[] args)
        {

            Console.WriteLine("Starting Azure Service Bus Demo");

            var connectionString = "Endpoint=sb://containerappjobspoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F0zXsuM/fi9oxRs1sfEsbHNaqmdB68kx+ASbGonLik=";

            var queueName = "basic-queue";


            var client = new ServiceBusClient(connectionString);


            ServiceBusSender sender = client.CreateSender(queueName);

            //await sender.SendMessageAsync(new ServiceBusMessage("This is a single message that we sent"));

            ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
            for (var x = 0; x < 10; x++)
            {
                batch.TryAddMessage(new ServiceBusMessage($"This is message {x} that we sent"));
            }

            await sender.SendMessagesAsync(batch);

        }
    }
}