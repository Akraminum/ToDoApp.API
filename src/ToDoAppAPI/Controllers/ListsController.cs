using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Dtos.Lists;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Repositories.IRepository;
using ToDoAppAPI.Services.ListsServices;

namespace ToDoAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListsController : ControllerBase
{
    private ILogger<ListsController> _logger;
    private IMapper _mapper;
    private IListService _listService;

    public ListsController(
        ILogger<ListsController> logger,
        IMapper mapper, 
        IListService listService 
    )
    {
        _logger = logger;
        _mapper = mapper;
        _listService = listService;
    }

    // GET api/lists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetListOutputDto>>> GetAll()
    {
        var output = await _listService.GetAll();
        return Ok(output);
    
    }
    
    // get list by id
    [HttpGet("{id}")]
    public async Task<ActionResult<GetListOutputDto>> GetById(
        [Range(1, int.MaxValue)] [FromRoute]int id
        )
    {
        var output = await _listService.GetById(id);
        if(output == null)
            return NotFound();
        return Ok(output);
    }


    // POST api/lists
    [HttpPost]
    public async Task<ActionResult<CreateListOutputDto>> Create(CreateListInputDto input)
    {
        var output = await _listService.Create(input);
        return CreatedAtAction(
            nameof(GetById), 
            new { id = output.Id }, 
            output);
    }


    // update list
    [HttpPut("{id}")]   
    public async Task<ActionResult<UpdateListOutputDto>> Update(UpdateListInputDto input)
    {
        var output = await _listService.Update(input);
        return Ok(output);
    }

    // delete list
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete( 
        [Range(1, int.MaxValue)] [FromRoute]int id)
    {
        await _listService.Delete(id);
        return Ok();
    }
}


