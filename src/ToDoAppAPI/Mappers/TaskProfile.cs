using AutoMapper;
using ToDoAppAPI.Dtos;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Mappers
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
        }
    }
}
