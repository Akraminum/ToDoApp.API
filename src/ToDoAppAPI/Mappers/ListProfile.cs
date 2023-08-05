using AutoMapper;
using ToDoAppAPI.Dtos;
using ToDoAppAPI.Dtos.Lists;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Mappers
{
    public class ListProfile : Profile
    {
        public ListProfile()
        {
            CreateMap<ListEntity, ListDto>();
            CreateMap<ListEntity, ListDetailsDto>();
            CreateMap<CreateListInputDto, ListEntity>();
            CreateMap<ListEntity, CreateListOutputDto>();
            
            CreateMap<ListEntity, GetListOutputDto>();

            CreateMap<ListEntity, UpdateListOutputDto>();
            CreateMap<UpdateListInputDto, ListEntity>();

            
            
            
        }
    }
}
