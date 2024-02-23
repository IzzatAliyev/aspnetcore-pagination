namespace App.Domain.Models
{
    public class PageList<T>(List<T> data, int pageNumber, int pageSize, int totalRecords)
    {
        public int PageNumber { get; init; } = pageNumber;
        public int PageSize { get; init; } = pageSize;
        public int TotalRecords { get; init; } = totalRecords;
        public int TotalPages { get; init; } = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize);
        public List<T> Data { get; init; } = data;
    }
}