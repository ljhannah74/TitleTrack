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

    [Fact]
    public async Task CreateTitleAbstract_ReturnsBadRequest_IfNull()
    {
        // Act
        var result = await _controller.CreateTitleAbstract(null);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Title Abstract cannot be null.", badRequest.Value);
    }

    [Fact]
    public async Task CreateTitleAbstract_ReturnsCreatedAtAction()
    {
        // Arrange
        var abstractItem = new TitleAbstract { TitleAbstractID = 1 };
        _mockRepo.Setup(r => r.AddTitleAbstractAsync(abstractItem)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CreateTitleAbstract(abstractItem);

        // Assert
        var createdAt = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(abstractItem, createdAt.Value);
    }

    [Fact]
    public async Task GetTitleAbstractByOrderNo_ReturnsNotFound_IfNotExists()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByOrderNoAsync("12345")).ReturnsAsync((TitleAbstract?)null);
        // Act

        var result = await _controller.GetTitleAbstractByOrderNo("12345");
        // Assert

        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Title Abstract with Order No 12345 not found.", notFound.Value);
    }

    [Fact]
    public async Task GetTitleAbstractByOrderNo_ReturnsOk_IfFound()
    {
        // Arrange
        var item = new TitleAbstract { OrderNo = "12345" };
        _mockRepo.Setup(r => r.GetByOrderNoAsync("12345")).ReturnsAsync(item);

        // Act
        var result = await _controller.GetTitleAbstractByOrderNo("12345");

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(item, ok.Value);
    }

    [Fact]
    public async Task UpdateTitleAbstract_ReturnsBadRequest_IfIdMismatch()
    {
        // Arrange
        var abstractItem = new TitleAbstract { TitleAbstractID = 2 };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new TitleAbstract { TitleAbstractID = 1 });

        // Act
        var result = await _controller.UpdateTitleAbstract(1, abstractItem);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Title Abstract data is invalid.", badRequest.Value);
    }

    [Fact]
    public async Task UpdateTitleAbstract_ReturnsOk_IfUpdated()
    {
        // Arrange
        var abstractItem = new TitleAbstract { TitleAbstractID = 1 };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(abstractItem);
        _mockRepo.Setup(r => r.UpdateTitleAbstractAsync(abstractItem)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateTitleAbstract(1, abstractItem);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}
