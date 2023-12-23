using Microsoft.EntityFrameworkCore;
using Sawnet.Core.BaseTypes;
using Sawnet.Core.Contracts;

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
        var query = await GetQueryableAsync();

        return await query.FirstOrDefaultAsync(_ => _.Id == id);
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

    protected Task<IQueryable<TAggregateRoot>> GetQueryableAsync()
    {
        var query = DbContext.Set<TAggregateRoot>().AsQueryable();

        return Task.FromResult(query);
    }
}
