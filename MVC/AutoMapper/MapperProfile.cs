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
		//MapperUsers

		CreateMap<GetAreaDto, UpdateAreaDto>().ReverseMap();

		CreateMap<GetOrganDto, UpdateOrganDto>().ReverseMap();

		CreateMap<GetProfessionDto, UpdateProfessionDto>().ReverseMap();

		CreateMap<GetRoleDto, UpdateRoleDto>().ReverseMap();

		CreateMap<GetUserByIdDto, UpdateUserDto>().ReverseMap();
	}
}
