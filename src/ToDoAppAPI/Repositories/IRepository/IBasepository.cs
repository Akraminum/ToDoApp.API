using System.Linq.Expressions;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Repositories.IBasepository;

public interface IBasepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
   Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FindById(TKey id);
    Task<TEntity?> GetById(TKey id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task Delete(TEntity entity);

}



