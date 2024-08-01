using MVC.Filters;

namespace MVC.Models.UserModels;
public class GetUserWithFlters
{
    public List<GetUsersDto> Users { get; set; } = null!;
    public UserFilters Filter { get; set; } = null!;
}