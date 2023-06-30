using AutoMapper;
using ToDoAppAPI.Dtos;
using ToDoAppAPI.Model;

namespace ToDoAppAPI.Mappers
{
    public class ListProfile: Profile
    {
        public ListProfile()
        {
            CreateMap<ListModel, ListDto>();
            CreateMap<ListModel, ListDetailsDto>();
        }
    }
}
