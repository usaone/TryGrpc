using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcGreeterClient.Tests;

public class GreeterClientTests : IClassFixture<WebApplicationFactory<GrpcGreeter.Program>>
{
    private readonly WebApplicationFactory<GrpcGreeter.Program> _factory;

    public GreeterClientTests(WebApplicationFactory<GrpcGreeter.Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GreeterClient_SayHello_ReturnsExpectedResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        using var channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions
        {
            HttpClient = client
        });

        var greeterClient = new Greeter.GreeterClient(channel);
        var request = new HelloRequest { Name = "Test" };

        // Act
        var response = await greeterClient.SayHelloAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Hello Test", response.Message);
    }

    [Fact]
    public async Task GreeterClient_SayHelloWithEmptyName_ReturnsCorrectResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        using var channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions
        {
            HttpClient = client
        });

        var greeterClient = new Greeter.GreeterClient(channel);
        var request = new HelloRequest { Name = "" };

        // Act
        var response = await greeterClient.SayHelloAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Hello ", response.Message);
    }

    [Fact]
    public void HelloRequest_SetName_PropertyIsSet()
    {
        // Arrange & Act
        var request = new HelloRequest { Name = "TestUser" };

        // Assert
        Assert.Equal("TestUser", request.Name);
    }

    [Fact]
    public void HelloReply_SetMessage_PropertyIsSet()
    {
        // Arrange & Act
        var reply = new HelloReply { Message = "Hello World" };

        // Assert
        Assert.Equal("Hello World", reply.Message);
    }
}