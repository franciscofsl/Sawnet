using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sawnet.Core.BaseTypes;
using Sawnet.Core.Contracts;
using Sawnet.Core.Specifications;
using Sawnet.Shared.Exceptions;

namespace Sawnet.Data.Repositories;

public class EfRepository<TAggregateRoot, TEntityId>
    : IRepository<TAggregateRoot, TEntityId>
    where TAggregateRoot : AggregateRoot<TEntityId>
    where TEntityId : EntityId
{
    public EfRepository(IDbContext context)
    {
        DbContext = context;
    }

    protected IDbContext DbContext { get; }

    public async Task<TAggregateRoot> GetAsync(TEntityId id)
    {
        var query = GetQueryableAsync();

        var entity = await query.FirstOrDefaultAsync(_ => _.Id == id);

        if (entity is null)
        {
            throw new EntityNotFoundException(id.Value, nameof(TAggregateRoot));
        }

        return entity;
    }

    public Task<List<TAggregateRoot>> GetListAsync(Filter<TAggregateRoot> filter = null)
    {
        var query = GetQueryableAsync();

        if (filter is not null)
        {
            var expression = filter.ToExpression();
            query = query.Where(expression);
        }

        return query.ToListAsync();
    }

    public Task<List<TReturnModel>> GetListAsync<TReturnModel>(Expression<Func<TAggregateRoot, TReturnModel>> map,
        Filter<TAggregateRoot> filter = null)
    {
        var query = GetQueryableAsync();

        if (filter is not null)
        {
            var expressionFilter = filter.ToExpression();
            query = query.Where(expressionFilter);
        }

        return query.Select(map).ToListAsync();
    }

    public async Task<TAggregateRoot> InsertAsync(TAggregateRoot entity, bool save = true)
    {
        await DbContext.Set<TAggregateRoot>().AddAsync(entity);
        if (save)
        {
            await DbContext.SaveChangesAsync();
        }

        return entity;
    }

    public async Task UpdateAsync(TAggregateRoot entity, bool save = true)
    {
        DbContext.Set<TAggregateRoot>().Update(entity);
        if (save)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(TAggregateRoot entity, bool save = true)
    {
        DbContext.Set<TAggregateRoot>().Remove(entity);
        if (save)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    protected IQueryable<TAggregateRoot> GetQueryableAsync()
    {
        var query = DbContext.Set<TAggregateRoot>().AsQueryable();

        query = ApplyIncludes(query);

        return query;
    }

    protected IQueryable<TAggregateRoot> GetQueryable()
    {
        var query = DbContext.Set<TAggregateRoot>().AsQueryable();

        return ApplyIncludes(query);
    }

    protected virtual IQueryable<TAggregateRoot> ApplyIncludes(IQueryable<TAggregateRoot> query)
    {
        return query;
    }
}