using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
namespace DataAccess;

public abstract class BaseDbRepository<T> : IBaseDbRepository<T>
  where T : class
{
    private readonly NotifyContext _context;

    public BaseDbRepository(NotifyContext context)
      => _context = context;

    public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        lock (new object())
        {
            _context.Set<T>().AddAsync(entity);
        }
        int createResult = await _context.SaveChangesAsync();
        return createResult > 0;
    }

    public async IAsyncEnumerable<T> GetAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        List<T> notificationEvents = await _context.Set<T>().AsNoTracking().ToListAsync();
        foreach (T notificationEvent in notificationEvents)
            yield return notificationEvent;
    }

    public async Task<bool> RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _context.RemoveRange(entities);
        int removeResult = await _context.SaveChangesAsync(cancellationToken);
        return removeResult > 0;
    }
}
