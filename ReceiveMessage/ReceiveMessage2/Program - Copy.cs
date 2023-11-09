//using Azure.Messaging.ServiceBus;


//namespace ConsoleApp1
//{
//    static class Program
//    {

//        static async Task Main(string[] args)
//        {

//            Console.WriteLine("[debug] Starting Azure Service Bus Demo " + DateTime.UtcNow.ToLongTimeString());
//            Thread.Sleep(1000);

//            var connectionString = "Endpoint=sb://containerappjobspoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F0zXsuM/fi9oxRs1sfEsbHNaqmdB68kx+ASbGonLik=";

//            var queueName = "basic-queue";


//            var client = new ServiceBusClient(connectionString);

//            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

//            // receive and process several messages at the same time
//            //IAsyncEnumerable<ServiceBusReceivedMessage> messageEnum = receiver.ReceiveMessagesAsync();
//            //if (messageEnum != null)
//            //{
//            //    await foreach (ServiceBusReceivedMessage? msg in messageEnum)
//            //    {

//            //        Console.WriteLine("Received Multiple Message: " + msg.Body);
//            //        await receiver.CompleteMessageAsync(msg);
//            //        Console.WriteLine("Completed Message: " + msg.Body);
//            //    }
//            //}
//            //else
//            //{
//            //    Console.WriteLine("Didnt receive a message");
//            //}
//            //try
//            //{
//            //    ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions { PrefetchCount = 50, MaxConcurrentCalls = 10 });
//            //    processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
//            //    processor.ProcessErrorAsync += Processor_ProcessErrorAsync;
//            //    Console.WriteLine("starting process message");
//            //    await processor.StartProcessingAsync();
//            //    Console.WriteLine("finished process message");
//            //}

//            // receive and process each message individually
//            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
//            if (message != null)
//            {
//                Console.WriteLine("[debug] Received Single Message: " + message.Body + DateTime.UtcNow.ToLongTimeString());

//                await receiver.CompleteMessageAsync(message);
//            }
//            else
//            {
//                Console.WriteLine("[debug] Didnt receive a message" + DateTime.UtcNow.ToLongTimeString());
//            }
//            try
//            {

//                ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions { PrefetchCount = 50, MaxConcurrentCalls = 10 });
//                processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
//                processor.ProcessErrorAsync += Processor_ProcessErrorAsync;
//                Console.WriteLine("[debug] Processor is ready" + DateTime.UtcNow.ToLongTimeString());
//                await processor.StartProcessingAsync();

//                //await receiver.CompleteMessageAsync(message);

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }


//            //Console.ReadLine();
//        }

//        private static Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
//        {
//            Console.WriteLine(arg.ToString());
//            return Task.CompletedTask;
//        }

//        private async static Task Processor_ProcessMessageAsync(ProcessMessageEventArgs arg)
//        {
//            try
//            {
//                ServiceBusReceivedMessage message = arg.Message;
//                Console.WriteLine("[debug] Received Processor Message: " + message.Body + DateTime.UtcNow.ToLongTimeString());
//                Thread.Sleep(60000);
//                await arg.CompleteMessageAsync(message);
//                Console.WriteLine("[debug] Completed message: " + message.Body + DateTime.UtcNow.ToLongTimeString());
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }
//            Environment.Exit(0);
//        }
//    }
//}