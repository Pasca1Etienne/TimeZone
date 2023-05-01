using System.Threading.Tasks;
using Grpc.Net.Client;
using RPCClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7117");
while(true)
{
    Console.WriteLine("Write <<greet>> to get greeted.");
    Console.WriteLine("Write <<time>> to get the time.");
    var input = Console.ReadLine();
    switch (input)
    {
        case "greet":
            await Greet();
            break;
        case "time":
            await GetTime();
            break;
        default:
            return;
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


async Task Greet()
{
    var client = new Greeter.GreeterClient(channel);

    Console.WriteLine("Enter your name:");
    var input = Console.ReadLine();
    var reply = await client.SayHelloAsync(new HelloRequest { Name = input });
    Console.WriteLine("Greeting: " + reply.Message);
}
async Task GetTime()
{
    var client = new Clock.ClockClient(channel);

    Console.WriteLine("Enter your timezone:");
    var input = Console.ReadLine();
    var reply = await client.GetTimeAsync(new TimeRequest { Timezone = input });
    
    if (reply is null)
        return;
    
    var ticks = reply.Message;
    var time = new DateTime(ticks);
    Console.WriteLine("Time: " + time);
}