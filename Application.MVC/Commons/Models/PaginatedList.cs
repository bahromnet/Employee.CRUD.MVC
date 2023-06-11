using Microsoft.EntityFrameworkCore;

namespace Application.MVC.Commons.Models;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public PaginatedList(IReadOnlyCollection<T> items, int pageNumber, int totalPages, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(totalCount / (double)totalPages);
        TotalCount = totalCount;
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNUmber,  int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNUmber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageNUmber, pageSize);
    }
}
