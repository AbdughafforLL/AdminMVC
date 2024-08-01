namespace MVC.Filters;
public abstract class PaginationFilter
{
	public int PageNumber { get; set; } = 1;
	public int PageSize { get; set; } = 20;
	public int PageCount { get; set; }
    public int TotalRecords { get; set; }
}