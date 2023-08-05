using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.DataBase;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Repositories.IRepository;

namespace ToDoAppAPI.Repositories;

public class ListRepository : Basepository<ListEntity, int>, IListRepository
{
    public ListRepository(
        ILogger<ListRepository> logger,
        AppDbContext dbContext
        ) : base(logger, dbContext){}


    public override async Task<ListEntity?> GetById(int id)
    {
        return await _dbContext.Set<ListEntity>().AsNoTracking()
                    .Include(x => x.Tasks!.Where(task => task.ListId == id))
                        .ThenInclude(t=>t.Priority)
                    .Include(x => x.Tasks!.Where(task => task.ListId == id))
                        .ThenInclude(t=>t.Steps)
                    .Include(x => x.AssociatedUsers)
                    .FirstOrDefaultAsync(x => x.Id == id);
    
    }

    public override async Task<List<ListEntity>> GetAll(Expression<Func<ListEntity, bool>>? predicate = null)
    {
        var q = _dbContext.Set<ListEntity>().AsNoTracking();
        if (predicate != null)
            q = q.Where(predicate);
        
        
        q = q.Include(x => x.Tasks)!
                .ThenInclude(t=>t.Priority)
            .Include(x => x.Tasks)!
                .ThenInclude(t=>t.Steps)
            .Include(x => x.AssociatedUsers);

        return await q.ToListAsync();
    
    }

}
