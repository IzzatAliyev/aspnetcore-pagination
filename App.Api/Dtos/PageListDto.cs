namespace App.Api.Dtos
{
    public record PageListDto<T>(int PageNumber, int PageSize, int TotalPages, int TotalRecords, List<T> Data);
}