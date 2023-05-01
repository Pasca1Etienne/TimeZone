using System.Threading.Tasks;
using Grpc.Net.Client;
using RPCClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7117");
while(true)
{
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
    var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
    Console.WriteLine("Greeting: " + reply.Message);
}
async Task GetTime()
{
    var client = new Clock.ClockClient(channel);
    var reply = await client.GetTimeAsync(new TimeRequest { Timezone = "GreeterClient" });
    Console.WriteLine("Time: " + reply.Message);
}