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

    [Fact]
    public async Task GetTitleAbstractById_ReturnsNotFound_IfNotExists()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((TitleAbstract?)null);

        // Act
        var result = await _controller.GetTitleAbstractById(1);

        // Assert
        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Title Abstract with ID 1 not found.", notFound.Value);
    }

    [Fact]
    public async Task GetTitleAbstractById_ReturnsOk_IfFound()
    {
        // Arrange
        var item = new TitleAbstract { TitleAbstractID = 1 };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(item);

        // Act
        var result = await _controller.GetTitleAbstractById(1);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(item, ok.Value);
    }
}
