using System.Security.Claims;
using AutoMapper;
using ConsistentApiResponseErrors.Exceptions;
using ToDoAppAPI.Dtos.Lists;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Repositories.IRepository;
using ToDoAppAPI.Services.IServices;

namespace ToDoAppAPI.Services.ListsServices;

public class ListService : IListService
{
    private readonly IMapper _mapper;
    private readonly ILogger<ListService> _logger;
    private readonly IListRepository _listRepository;
    private readonly IUserProvider _userProvider;

    public ListService(
        IMapper mapper,
        ILogger<ListService> logger,
        IListRepository listRepository,
        IUserProvider userProvider
    )
    {
        _mapper = mapper;
        _logger = logger;
        _userProvider = userProvider;
        _listRepository = listRepository;
    } 

    // create list
    public async Task<CreateListOutputDto> Create(CreateListInputDto entity)
    {
        var list = _mapper.Map<ListEntity>(entity);
        _logger.LogInformation("Creating list");

        string userId = _userProvider.GetUserId();
       
        list.OwnerId = userId;
        await _listRepository.Create(list);

        _logger.LogInformation("List created");
        return _mapper.Map<CreateListOutputDto>(list);
    }

    public async Task<List<GetListOutputDto>> GetAll()
    {
        string userId = _userProvider.GetUserId();

        return _mapper.Map<List<GetListOutputDto>>(await _listRepository.GetAll());
    }

    public async Task<GetListOutputDto?> GetById(int id)
    {
        return _mapper.Map<GetListOutputDto>(await _listRepository.GetById(id));
    }

    public async Task<UpdateListOutputDto> Update(UpdateListInputDto entity)
    {
        // get list by id
        ListEntity? list = await _listRepository.FindById(entity.Id);
        if (list == null)
            throw new Exception($"List {entity.Id} Not Found");
        
        // check if user is owner of list
        var userId = _userProvider.GetUserId();

        // update list
        _mapper.Map(entity, list);
        await _listRepository.Update(list);

        // return updated list
        return _mapper.Map<UpdateListOutputDto>(list);
    }

    public async Task Delete(int id)
    {
        var list = await _listRepository.FindById(id);
        if (list == null)
            throw new Exception($"List {id} Not Found");
            
        await _listRepository.Delete(list);
    }

}
