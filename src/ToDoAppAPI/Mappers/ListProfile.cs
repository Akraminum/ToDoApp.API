using AutoMapper;
using ToDoAppAPI.Dtos;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Mappers
{
    public class ListProfile : Profile
    {
        public ListProfile()
        {
            CreateMap<ListEntity, ListDto>();
            CreateMap<ListEntity, ListDetailsDto>();
        }
    }
}
