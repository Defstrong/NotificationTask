namespace BusinessLogic;

public interface IBaseService<T>
  where T : class
{
    Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default);
    IAsyncEnumerable<T> GetAsync(CancellationToken cancellationToken);
}
