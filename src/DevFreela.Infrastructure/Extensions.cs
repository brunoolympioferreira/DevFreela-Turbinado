using DevFreela.Core;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure;
public static class Extensions
{
    public static async Task<PaginationResult<T>> GetPaged<T>(
        this IQueryable<T> query,
        int Page,
        int pageSize) where T : class
    {
        var result = new PaginationResult<T>();

        result.Page = Page;
        result.PageSize = pageSize;
        result.ItemsCount = await query.CountAsync();

        var pegeCount = (double)result.ItemsCount / pageSize;
        result.TotalPages = (int)Math.Ceiling(pegeCount);

        var skip = (Page - 1) * pageSize;

        result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
}
