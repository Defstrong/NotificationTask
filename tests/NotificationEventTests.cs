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
    public async Task CreateAsync_NullArgument_ThrowsArgumentNullException()
    {
        var service = new NotificationEventService(_mockRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.CreateAsync(null));
    }

    // [Fact]
    // public async Task NotificationEventService_GetAsync_Success()
    // {
    //     // Arrange
    //     var options = new DbContextOptionsBuilder<NotifyDbContext>()
    //         .UseInMemoryDatabase(databaseName: "TestDatabase")
    //         .Options;
    //
    //     using (var context = new NotifyDbContext(options))
    //     {
    //         context.Set<DbNotificationEvent>().Add(new DbNotificationEvent { /* add properties */ });
    //         context.SaveChanges();
    //     }
    //
    //     var mockRepository = new Mock<INotificationEventRepository>();
    //     mockRepository.Setup(repo => repo.GetAsync(It.IsAny<CancellationToken>()))
    //         .ReturnsAsync(context => context.Set<DbNotificationEvent>().AsAsyncEnumerable());
    //
    //     var service = new NotificationEventService(mockRepository.Object);
    //
    //     // Act
    //     var result = await service.GetAsync(CancellationToken.None).ToListAsync();
    //
    //     // Assert
    //     Assert.Single(result);
    //     mockRepository.Verify(repo => repo.GetAsync(It.IsAny<CancellationToken>()), Times.Once());
    // }
}

