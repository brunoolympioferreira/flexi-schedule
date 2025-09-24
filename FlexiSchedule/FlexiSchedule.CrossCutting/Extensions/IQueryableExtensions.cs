using FlexiSchedule.CrossCutting.Models;
using Microsoft.EntityFrameworkCore;

namespace FlexiSchedule.CrossCutting.Extensions;

public static class IQueryableExtensions
{
    /// <summary>
    /// Converte uma consulta IQueryable em um resultado paginado de forma assíncrona.
    /// </summary>
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await GetPagedItemsAsync(query, pageNumber, pageSize, cancellationToken);

        return CreatePagedResult(items, totalCount, pageNumber, pageSize);
    }

    /// <summary>
    /// Converte uma consulta IQueryable em um resultado paginado de forma síncrona.
    /// </summary>
    public static PagedResult<T> ToPagedResult<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize)
    {
        var totalCount = query.Count();
        var items = GetPagedItems(query, pageNumber, pageSize);

        return CreatePagedResult(items, totalCount, pageNumber, pageSize);
    }

    #region Métodos auxiliares privados

    private static async Task<List<T>> GetPagedItemsAsync<T>(
        IQueryable<T> query,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    private static List<T> GetPagedItems<T>(
        IQueryable<T> query,
        int pageNumber,
        int pageSize)
    {
        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    private static PagedResult<T> CreatePagedResult<T>(
        List<T> items,
        int totalCount,
        int pageNumber,
        int pageSize)
    {
        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    #endregion
}