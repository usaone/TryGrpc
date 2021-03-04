# **TryGrpc**

I used the following link to try Grpc and learn more about it:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-5.0&tabs=visual-studio

Below is the content of the program.cs file in the **GrpcGreeterClient** project.

```
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
  class Program
  {
    static async Task Main(string[] args)
    {
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");

      var client = new Greeter.GreeterClient(channel);
      
      var reply = await client.SayHelloAsync(
                        new HelloRequest { Name = "GreeterClient" });
      Console.WriteLine("Greeting: " + reply.Message);

      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
```



Overall, this is a great tool.