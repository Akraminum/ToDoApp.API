using ToDoAppAPI.Dtos.Lists;

namespace ToDoAppAPI.Services.ListsServices;

public interface IListService
{
    Task<CreateListOutputDto> Create(CreateListInputDto entity);

    Task<List<GetListOutputDto>> GetAll();

    Task<GetListOutputDto?> GetById(int id);

    Task<UpdateListOutputDto> Update(UpdateListInputDto entity);

    Task Delete(int id);

}
