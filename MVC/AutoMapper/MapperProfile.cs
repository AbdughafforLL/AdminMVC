using AutoMapper;
using MVC.Entities;
using MVC.Models.UserModels;
namespace MVC.AutoMapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, GetUsersDto>();
    }
}
