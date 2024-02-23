namespace DataAccess;

public abstract class BackgroundWorker : IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource;
    private Timer? _timer;

    protected virtual async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        while (!cancellationToken.IsCancellationRequested)
        {
            _timer = new Timer(async (_) => await DoWorkAsync(), null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        }
        await Task.Delay(50);
    }

    protected abstract Task DoWorkAsync(CancellationToken cancellationToken = default);

    public async Task StartAsync(CancellationToken cancellationToken = default)
        => await ExecuteAsync(cancellationToken);

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        if (_cancellationTokenSource != null)
            _cancellationTokenSource.Cancel();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Dispose();
    }
}
