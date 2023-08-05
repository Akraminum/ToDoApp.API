using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.DataBase;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Repositories.IBasepository;

namespace ToDoAppAPI.Repositories;

public class Basepository<TEntity, TKey> : IBasepository<TEntity, TKey> 
    where TEntity : BaseEntity<TKey>
{
    protected ILogger<ListRepository> _logger;
    protected AppDbContext _dbContext;

    public Basepository(
        ILogger<ListRepository> logger,
        AppDbContext dbContext
        )
    {
        _logger = logger;
        _dbContext = dbContext;
    }


    public async Task<TEntity> Create(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var q = _dbContext.Set<TEntity>().AsNoTracking();
        if (predicate != null)
            q = q.Where(predicate);

        return q.ToListAsync();
    }

    public async Task<TEntity?> FindById(TKey id)
    {
        return await _dbContext.Set<TEntity>().Where(x => x.Id!.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> GetById(TKey id)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id!.Equals(id));
    }

   
}
