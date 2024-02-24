using BusinessLogic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation;

[ApiController]
[Route("[controller]")]
public class NotificationEventController : ControllerBase
{
    private readonly INotificationEventService _notificationEventService;
    private readonly NotificationWorker _backgroundWorker;

    public NotificationEventController(INotificationEventService notificationEventService, NotificationWorker backgroundWorker)
    {
        _notificationEventService = notificationEventService;
        _backgroundWorker = backgroundWorker;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(NotificationEventDto notificationEvent, CancellationToken cancellationToken = default)
    {
        bool createResult = await _notificationEventService.CreateAsync(notificationEvent, cancellationToken);

        if (createResult)
            return Ok("Operation completed successfully");
        else
            return BadRequest("Something went wrong please try again later");
    }

    [HttpGet]
    public async IAsyncEnumerable<NotificationEventDto> GetAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (NotificationEventDto notificationEvent in _notificationEventService.GetAsync(cancellationToken))
            yield return notificationEvent;
    }
}
