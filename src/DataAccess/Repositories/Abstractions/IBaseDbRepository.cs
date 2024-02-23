namespace DataAccess;

public interface IBaseDbRepository<T>
  where T : class
{
    Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default);
    IAsyncEnumerable<T> GetAsync(CancellationToken cancellationToken = default);
    public Task<bool> RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
