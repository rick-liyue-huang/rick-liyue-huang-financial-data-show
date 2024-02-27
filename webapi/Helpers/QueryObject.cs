namespace webAPI.Helpers
{
  public class QueryObject
  {
    // here we define the properties for query parameters, sorting and filtering and pagination.
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;

    public string? SortBy { get; set; } = null;

    public bool IsDescending { get; set; } = false;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

  }
}