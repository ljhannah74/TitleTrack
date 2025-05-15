using Moq;
using TitleTrackAPI.Controllers;
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
}
