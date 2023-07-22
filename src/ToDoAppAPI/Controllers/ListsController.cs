//using AutoMapper;
//using Azure.Core;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Linq;
//using System.Threading.Tasks;
//using ToDoAppAPI.DataBase;
//using ToDoAppAPI.Dtos;
//using ToDoAppAPI.Model;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace ToDoAppAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ListsController : ControllerBase
//    {
//        private readonly AppDbContext _dbContext;
//        private readonly IMapper _mapper;

//        public ListsController(AppDbContext dbContext, IMapper mapper)
//        {
//            _dbContext = dbContext;
//            _mapper = mapper;
//        }


//        [HttpGet]
//        public ActionResult<List<ListDto>> GetLists([FromQuery] ListQueryParamsDto queryParamsDto)
//        {

//            var ListsEntities = _dbContext.Lists
//                            .Include(l=>l.Tasks)
//                            .AsQueryable();


//            if (!string.IsNullOrEmpty(queryParamsDto.Search)) 
//            {
//                ListsEntities = ListsEntities.Include(l => l.Tasks!.Where(t =>
//                                                            t.Title.Contains(queryParamsDto.Search)));
//                                            //.ThenInclude(t=>t.Steps.Where(s=>
//                                            //            s.Name.Contains(queryParamsDto.Search))); 

//                ListsEntities = ListsEntities.Where(l => l.Name.Contains(queryParamsDto.Search));
//            }

//            //_dbContext.Lists.Where(l => l.Users.Where(u=>u.Id==1).Count()>0); // << ??

//            Console.WriteLine("========================"); 
//            Console.WriteLine(ListsEntities.ToQueryString());
//            Console.WriteLine("========================");


//            var Dtos = _mapper.Map<List<ListDto>>(ListsEntities);
//            return Ok(Dtos);
//        }


//        // GET api/<ListsController>/5
//        [HttpGet("{id}")]
//        public ActionResult<ListDetailsDto> GetListById(int id)
//        {
//            var ListEntity = _dbContext.Lists
//                                .Where(l => l.Id == id)
//                                .Include(l => l.Tasks!)
//                                    .ThenInclude(t => t.Steps!);

//            return Ok(_mapper.Map<ListDetailsDto>(ListEntity));
//        }

//        // POST api/<ListsController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ListsController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ListsController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
