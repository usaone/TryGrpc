using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;

namespace GrpcGreeter.Tests;

public class GreeterServiceTests
{
    private readonly Mock<ILogger<GreeterService>> _mockLogger;
    private readonly GreeterService _greeterService;

    public GreeterServiceTests()
    {
        _mockLogger = new Mock<ILogger<GreeterService>>();
        _greeterService = new GreeterService(_mockLogger.Object);
    }

    [Fact]
    public async Task SayHello_WithValidRequest_ReturnsCorrectResponse()
    {
        // Arrange
        var request = new HelloRequest { Name = "World" };
        var context = new Mock<ServerCallContext>().Object;

        // Act
        var result = await _greeterService.SayHello(request, context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello World", result.Message);
    }

    [Fact]
    public async Task SayHello_WithEmptyName_ReturnsHelloWithEmptyString()
    {
        // Arrange
        var request = new HelloRequest { Name = "" };
        var context = new Mock<ServerCallContext>().Object;

        // Act
        var result = await _greeterService.SayHello(request, context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello ", result.Message);
    }

    [Fact]
    public async Task SayHello_WithNullName_ReturnsHelloWithEmpty()
    {
        // Arrange
        var request = new HelloRequest();  // Name defaults to empty string in protobuf
        var context = new Mock<ServerCallContext>().Object;

        // Act
        var result = await _greeterService.SayHello(request, context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hello ", result.Message);
    }
}