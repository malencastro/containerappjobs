using Azure.Messaging.ServiceBus;

var connectionString = "Endpoint=sb://containerappjobspoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F0zXsuM/fi9oxRs1sfEsbHNaqmdB68kx+ASbGonLik=";
var queueName = "basic-queue";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);


// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);



#region Receive all messages

// receive all messages
//IAsyncEnumerable<ServiceBusReceivedMessage> messages = receiver.ReceiveMessagesAsync();
//await foreach (ServiceBusReceivedMessage? message in messages)
// {
//    // get the message body as a string
//    var body = message.Body.ToString();
//    Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message received] - " + body);
//    await receiver.CompleteMessageAsync(message);
//    Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message completed]");
//}

#endregion



#region Receive single message

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
var body = receivedMessage.Body.ToString();
Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message received] - " + body);
await receiver.CompleteMessageAsync(receivedMessage);
Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message completed]");

#endregion



#region Receive single message and send exceptions to Deadletter

//// the received message is a different type as it contains some service set properties
//ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

//// get the message body as a string
//var body = receivedMessage.Body.ToString();
//Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message received] - " + body);
//if (receivedMessage.Body.ToString().Contains("2"))
//{
//    await receiver.DeadLetterMessageAsync(receivedMessage);
//    Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message deadlettered]");
//}
//else
//{
//    await receiver.CompleteMessageAsync(receivedMessage);
//    Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message completed]");
//}

#endregion



#region Receive several messages and send exceptions to Deadletter

//// receive all messages
//IAsyncEnumerable<ServiceBusReceivedMessage> messages = receiver.ReceiveMessagesAsync();
//await foreach (ServiceBusReceivedMessage? message in messages)
//{
//    // get the message body as a string
//    var body = message.Body.ToString();
//    Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message received] - " + body);
//    if (message.Body.ToString().Contains("2"))
//    {
//        await receiver.DeadLetterMessageAsync(message);
//        Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message deadlettered]");
//    }
//    else
//    {
//        await receiver.CompleteMessageAsync(message);
//        Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + " [DEBUG - message completed]");
//    }
//}

#endregion