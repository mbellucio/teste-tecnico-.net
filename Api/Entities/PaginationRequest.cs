public class PaginationRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    private const int MaxPageSize = 100;
    public int GetPageSize() => Math.Min(PageSize, MaxPageSize);
}