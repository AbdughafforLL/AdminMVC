namespace MVC.Filters;
public class UserFilters : PaginationFilter
{
    public string? PhoneNumber { get; set; }
    public string? Inn { get; set; }
    public string? Name { get; set; }
}