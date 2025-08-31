# **TryGrpc**

A gRPC learning project demonstrating client-server communication using ASP.NET Core and .NET 8.0.

## Original Reference

I used the following link to try gRPC and learn more about it:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-5.0&tabs=visual-studio

## Project Structure

The solution contains the following projects:

- **GrpcGreeter** - gRPC server hosting the Greeter service
- **GrpcGreeterClient** - Console client application that connects to the server
- **GrpcGreeter.Tests** - Unit tests for the server project
- **GrpcGreeterClient.Tests** - Integration and unit tests for the client project

## Client Example

Below is the content of the program.cs file in the **GrpcGreeterClient** project:

```csharp
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

## Change Log

### August 31, 2025 - Major Update to .NET 8.0 and Latest gRPC Packages

**Framework Upgrade:**
- Updated target framework from `netcoreapp3.1` to `net8.0` for both projects
- Migrated to latest .NET 8.0 runtime and SDK features

**Package Updates:**
- **GrpcGreeter (Server)**:
  - Grpc.AspNetCore: `2.27.0` → `2.66.0`
- **GrpcGreeterClient (Client)**:
  - Google.Protobuf: `3.15.3` → `3.28.2`
  - Grpc.Net.Client: `2.35.0` → `2.66.0`
  - Grpc.Tools: `2.36.0` → `2.66.0`

**Test Projects Added:**

1. **GrpcGreeter.Tests**
   - Framework: .NET 8.0 with xUnit
   - Dependencies:
     - Microsoft.AspNetCore.Mvc.Testing 8.0.0
     - Moq 4.20.72
     - xunit 2.9.2
   - Test Coverage:
     - Unit tests for GreeterService.SayHello method
     - Tests for various input scenarios (valid, empty, null)
     - Mock-based testing with ILogger

2. **GrpcGreeterClient.Tests**
   - Framework: .NET 8.0 with xUnit  
   - Dependencies:
     - Microsoft.AspNetCore.Mvc.Testing 8.0.0
     - Grpc.Net.Client 2.66.0
     - Moq 4.20.72
     - xunit 2.9.2
   - Test Coverage:
     - Integration tests using TestHost for end-to-end gRPC communication
     - Unit tests for protobuf message types
     - Tests both server and client interaction patterns

**Solution Structure:**
- Added test projects to respective solution files
- All projects now target .NET 8.0 consistently
- Updated project references and dependencies

**Test Results:**
- **Total Tests**: 9 (4 server tests + 5 client tests)
- **Status**: All tests passing
- **Coverage**: Unit tests, integration tests, and property validation tests

**Build Verification:**
- All projects compile successfully on .NET 8.0
- No breaking changes from framework migration
- Package compatibility verified with latest gRPC versions

This update modernizes the solution with the latest .NET and gRPC packages while adding comprehensive test coverage for both client and server functionality.

## Running the Solution

1. **Start the server**: Run the GrpcGreeter project (will start on https://localhost:5001)
2. **Run the client**: Execute the GrpcGreeterClient project to connect and test
3. **Run tests**: Use `dotnet test` to execute all unit and integration tests

## Testing

Run all tests:
```bash
dotnet test
```

Run specific test projects:
```bash
dotnet test GrpcGreeter.Tests
dotnet test GrpcGreeterClient.Tests
```

Overall, this is a great tool for learning gRPC fundamentals with modern .NET development practices.