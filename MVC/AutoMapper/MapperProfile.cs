using MVC.Entities;
using MVC.Models.AreaModels;
using MVC.Models.OrganModels;
using MVC.Models.RoleModels;
using MVC.Models.StatusModels;
using MVC.Models.UserModels;
namespace MVC.AutoMapper;
public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Area, GetAreaDto>().ReverseMap();
		CreateMap<Area, CreateAreaDto>().ReverseMap();
		CreateMap<Area, UpdateAreaDto>().ReverseMap();
		CreateMap<GetAreaDto, UpdateAreaDto>().ReverseMap();

		CreateMap<Organ, GetOrganDto>().ReverseMap();
		CreateMap<Organ, CreateOrganDto>().ReverseMap();
		CreateMap<Organ, UpdateOrganDto>().ReverseMap();
		CreateMap<GetOrganDto, UpdateOrganDto>().ReverseMap();

		CreateMap<Status, GetStatusDto>().ReverseMap();
		CreateMap<Status, CreateStatusDto>().ReverseMap();
		CreateMap<Status, UpdateStatusDto>().ReverseMap();
		CreateMap<GetStatusDto, UpdateStatusDto>().ReverseMap();

		CreateMap<Role, GetRoleDto>().ReverseMap();
		CreateMap<Role, CreateRoleDto>().ReverseMap();
		CreateMap<Role, UpdateRoleDto>().ReverseMap();
		CreateMap<GetRoleDto, UpdateRoleDto>().ReverseMap();

		CreateMap<User, GetUserByIdDto>().ReverseMap();
		CreateMap<User, CreateUserDto>().ReverseMap();
		CreateMap<User, UpdateUserDto>().ReverseMap();
		CreateMap<GetUserByIdDto, UpdateUserDto>().ReverseMap();
	}
}
