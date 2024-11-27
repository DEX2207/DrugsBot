﻿using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

public interface IReadRepository<T> where T: class
{
    /// <summary>
    /// Получение сущности по ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IQueryable> GetQueryableAsync(ODataQueryOptions<T> queryOptions,
        CancellationToken cancellationToken = default);
}