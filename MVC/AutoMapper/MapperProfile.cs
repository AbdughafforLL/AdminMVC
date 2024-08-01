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
		CreateMap<DataRow, GetUserByIdDto>()
			.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src["user_id"]))
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src["user_name"]))
			.ForMember(dest => dest.Ips, opt => opt.MapFrom(src => src["ips"]))
			.ForMember(dest => dest.Inn, opt => opt.MapFrom(src => src["inn"]))
			.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src["first_name"]))
			.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src["last_name"]))
			.ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src["middle_name"]))
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src["full_name"]))
			.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src["phone_number"]))
			.ForMember(dest => dest.AdrText, opt => opt.MapFrom(src => src["adr_text"]))
			.ForMember(dest => dest.AdrEmail, opt => opt.MapFrom(src => src["adr_email"]))
			.ForMember(dest => dest.AdrWebSite, opt => opt.MapFrom(src => src["adr_website"]))
			.ForMember(dest => dest.ProfessionName, opt => opt.MapFrom(src => src["profession_name"]))
			.ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src["created_user"]))
			.ForMember(dest => dest.OrganName, opt => opt.MapFrom(src => src["organ_name"]))
			.ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => src["hash_password"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));

		CreateMap<DataRow, GetUsersDto>()
			.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src["user_id"]))
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src["user_name"]))
			.ForMember(dest => dest.Ips, opt => opt.MapFrom(src => src["ips"]))
			.ForMember(dest => dest.Inn, opt => opt.MapFrom(src => src["inn"]))
			.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src["first_name"]))
			.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src["last_name"]))
			.ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src["middle_name"]))
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src["full_name"]))
			.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src["phone_number"]))
			.ForMember(dest => dest.AdrText, opt => opt.MapFrom(src => src["adr_text"]))
			.ForMember(dest => dest.AdrEmail, opt => opt.MapFrom(src => src["adr_email"]))
			.ForMember(dest => dest.AdrWebSite, opt => opt.MapFrom(src => src["adr_website"]))
			.ForMember(dest => dest.ProfessionName, opt => opt.MapFrom(src => src["profession_name"]))
			.ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src["created_user"]))
			.ForMember(dest => dest.OrganName, opt => opt.MapFrom(src => src["organ_name"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));

		//MapperArea
		CreateMap<DataRow, GetAreaDto>()
			.ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src["area_id"]))
			.ForMember(dest => dest.AreaName, opt => opt.MapFrom(src => src["area_name"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));
		//MapperOrgan
		CreateMap<DataRow, GetOrganDto>()
			.ForMember(dest => dest.OrganId, opt => opt.MapFrom(src => src["organ_id"]))
			.ForMember(dest => dest.OrganName, opt => opt.MapFrom(src => src["organ_name"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));
		//MapperProfession
		CreateMap<DataRow, GetProfessionDto>()
			.ForMember(dest => dest.ProfessionId, opt => opt.MapFrom(src => src["profession_id"]))
			.ForMember(dest => dest.ProfessionName, opt => opt.MapFrom(src => src["profession_name"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));
		//MapperRole
		CreateMap<DataRow, GetRoleDto>()
			.ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src["role_id"]))
			.ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src["role_name"]))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src["created_at"]))
			.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src["updated_at"]));

		CreateMap<GetAreaDto, UpdateAreaDto>().ReverseMap();
		CreateMap<GetOrganDto, UpdateOrganDto>().ReverseMap();
		CreateMap<GetProfessionDto, UpdateProfessionDto>().ReverseMap();
		CreateMap<GetRoleDto, UpdateRoleDto>().ReverseMap();
		CreateMap<GetUserByIdDto, UpdateUserDto>().ReverseMap();
	}
}