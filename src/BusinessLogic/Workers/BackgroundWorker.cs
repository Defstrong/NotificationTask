namespace BusinessLogic;

public abstract class BackgroundWorker : IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource;
    private Timer? _timer;

    protected virtual Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _timer = new Timer(async (_) => await DoWorkAsync(cancellationToken), null, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15));
        return Task.CompletedTask;
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
