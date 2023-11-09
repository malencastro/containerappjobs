//using Microsoft.Azure.ServiceBus;
//using System.Text;

//class Program
//{
//    const string _serviceBusConnectionString = "Endpoint=sb://containerappjobspoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F0zXsuM/fi9oxRs1sfEsbHNaqmdB68kx+ASbGonLik=";
//    const string _queueName = "basic-queue";
//    static IQueueClient? _queueClient;

//    static async Task Main(string[] args)
//    {
//        _queueClient = new QueueClient(_serviceBusConnectionString, _queueName);
//        Console.WriteLine("[debug] Main " + DateTime.UtcNow.ToLongTimeString());
//        RegisterOnMessageHandlerAndReceiveMessages();
//        Console.WriteLine("Press any key to exit.");
//        Console.ReadLine();
//        //await _queueClient.CloseAsync();
//    }

//    static void RegisterOnMessageHandlerAndReceiveMessages()
//    {

//        Console.WriteLine("[debug] RegisterOnMessageHandlerAndReceiveMessages " + DateTime.UtcNow.ToLongTimeString());
//        var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
//        {
//            MaxConcurrentCalls = 1,
//            AutoComplete = false // Set to false if you want to manually complete the message.
//        };
//        if (_queueClient is null)
//        {
//            Console.WriteLine("[debug] _queueClient in null " + DateTime.UtcNow.ToLongTimeString());
//        }
//        else
//        {
//            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
//        }
//    }

//    static async Task ProcessMessagesAsync(Message message, CancellationToken token)
//    {
//        try
//        {
//            Console.WriteLine($"[debug] Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}" + DateTime.UtcNow.ToLongTimeString());

//            // Processing logic goes here. You can add your business logic.
//            Console.WriteLine("[debug] Received Processor Message: " + message.Body + DateTime.UtcNow.ToLongTimeString());
//            Thread.Sleep(3000);
//            // Complete the message to remove it from the queue.
//            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
//            Console.WriteLine("[debug] completed " + message.Body + DateTime.UtcNow.ToLongTimeString());
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("[debug] some exception " + ex.Message + message.Body + DateTime.UtcNow.ToLongTimeString());
//        }
//        finally
//        {
//            Console.WriteLine("[debug] finally " + message.Body + DateTime.UtcNow.ToLongTimeString());
//            await _queueClient.CloseAsync();
//            Environment.Exit(0);
//        }

//    }

//    static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
//    {
//        Console.WriteLine($"[debug] Message handler encountered an exception: {exceptionReceivedEventArgs.Exception}." + DateTime.UtcNow.ToLongTimeString());
//        return Task.CompletedTask;
//    }
//}