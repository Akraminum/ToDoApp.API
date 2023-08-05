using System.Linq.Expressions;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Repositories.IBasepository;

namespace ToDoAppAPI.Repositories.IRepository;

public interface IListRepository : IBasepository<ListEntity, int> 
{
    // Task<ListEntity?> GetByName(string name);
}
