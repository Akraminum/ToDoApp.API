using AutoMapper;
using ToDoAppAPI.Dtos.Account;
using ToDoAppAPI.Dtos.Users;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserInputDto, UserEntity>();
        CreateMap<UserEntity, CreateUserOutputDto>();
        CreateMap<UserEntity, GetUserOutputDto>();

        // account
        CreateMap<UpdateInputDto, UserEntity>();
    }
}


