using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataAccess;

public abstract class BaseDbRepository<T> : IBaseDbRepository<T>
  where T : class
{
    private readonly NotifyDbContext _context;

    public BaseDbRepository(NotifyDbContext context)
      => _context = context;

    public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        int createResult;
        lock (new object())
        {
            _context.Set<T>().AddAsync(entity);
        }
        try
        {
            createResult = await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return createResult > 0;
    }

    public async IAsyncEnumerable<T> GetAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        List<T> notificationEvents = await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        foreach (T notificationEvent in notificationEvents)
            yield return notificationEvent;
    }

    public async Task<bool> RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _context.RemoveRange(entities);
        int removeResult = await _context.SaveChangesAsync(cancellationToken);
        return removeResult > 0;
    }

    public async Task<bool> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        foreach (T entity in entities)
            _context.Entry(entity).State = EntityState.Modified;

        int updateResult = await _context.SaveChangesAsync(cancellationToken);
        return updateResult > 0;
    }
}
