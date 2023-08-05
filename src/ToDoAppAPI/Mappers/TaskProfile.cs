using AutoMapper;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Tasks.Dtos;

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
