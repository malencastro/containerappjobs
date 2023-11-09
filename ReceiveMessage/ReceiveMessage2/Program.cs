using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://containerappjobspoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F0zXsuM/fi9oxRs1sfEsbHNaqmdB68kx+ASbGonLik=";
string queueName = "basic-queue";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);


// create a receiver that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);
await receiver.CompleteMessageAsync(receivedMessage);