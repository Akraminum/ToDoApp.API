using AutoMapper;
using ToDoAppAPI.Dtos;
using ToDoAppAPI.Model;

namespace ToDoAppAPI.Mappers
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskModel, TaskDto>();
        }
    }
}
