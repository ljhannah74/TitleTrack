using Microsoft.AspNetCore.Mvc;
using Moq;
using TitleTrackAPI.Controllers;
using TitleTrackAPI.Models;
using TitleTrackAPI.Repositories;

namespace TitleTrackAPI.Tests;

public class TitleAbstractControllerTests
{
    private readonly Mock<ITitleAbstractRepository> _mockRepo;
    private readonly TitleAbstractController _controller;

    public TitleAbstractControllerTests()
    {
        _mockRepo = new Mock<ITitleAbstractRepository>();
        _controller = new TitleAbstractController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllTitleAbstracts_ReturnsOkWithList()
    {
        // Arrange
        var list = new List<TitleAbstract> { new TitleAbstract(), new TitleAbstract() };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(list);

        // Act
        var result = await _controller.GetAllTitleAbstracts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(list, okResult.Value);
    }
}
