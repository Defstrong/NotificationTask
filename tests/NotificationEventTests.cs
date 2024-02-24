using BusinessLogic;
using DataAccess;
using Moq;

public class NotificationEventServiceTest
{
    private readonly Mock<INotificationEventRepository> _mockRepository;

    public NotificationEventServiceTest()
    {
        _mockRepository = new Mock<INotificationEventRepository>();
    }

    [Fact]
    public async Task CreateAsync_ValidData_ReturnsTrueAndSavesEvent()
    {
        // Arrange
        var notificationEvent = new NotificationEventDto
        {
            OrderType = "Purchase",
            SessionId = "29827525-06c9-4b1e-9d9b-7c4584e82f56",
            Card = "4433**1409",
            EventDate = "2023-01-04 13:44:52.835626 +00:00",
            WebsiteUrl = "https://amazon.com"
        };

        _mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(true);

        var service = new NotificationEventService(_mockRepository.Object);

        // Act
        bool result = await service.CreateAsync(notificationEvent);

        // Assert
        Assert.True(result);
        _mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task CreateAsync_ValidData_ReturnsFalseAndSavesEvent()
    {
        // Arrange
        var notificationEvent = new NotificationEventDto
        {
            OrderType = "Purchase",
            SessionId = "29827525-06c9-4b1e-9d9b-7c4584e82f56",
            Card = "4433**1409",
            EventDate = "2023-01-04 13:44:52.835626 +00:00",
            WebsiteUrl = "https://amazon.com"
        };

        _mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var service = new NotificationEventService(_mockRepository.Object);

        // Act
        bool firstResult = await service.CreateAsync(notificationEvent);

        // Assert
        Assert.True(firstResult);
        _mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()), Times.Once());

        _mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        // Act
        bool secondResult = await service.CreateAsync(notificationEvent);

        // Assert
        Assert.False(secondResult);
        _mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<DbNotificationEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
    }
}

