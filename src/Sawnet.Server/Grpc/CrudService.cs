using Sawnet.Application.Cqrs.Commands;
using Sawnet.Application.Cqrs.Queries;
using Sawnet.Blazor.Shared.Grpc;
using Sawnet.Blazor.Shared.Grpc.Filters;

namespace Sawnet.Server.Grpc;

public abstract class CrudService<TEntityDto, TCreateDto, TForListDto, TFilter>
    : ICrudService<TEntityDto, TCreateDto, TForListDto, TFilter>
{
    public CrudService(IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher)
    {
        QueryDispatcher = queryDispatcher;
        CommandDispatcher = commandDispatcher;
    }

    protected IQueryDispatcher QueryDispatcher { get; }
    protected ICommandDispatcher CommandDispatcher { get; }
    
    public abstract Task<TEntityDto> CreateAsync(TCreateDto createDto);

    public abstract Task<TEntityDto> UpdateAsync(TEntityDto dto);

    public abstract Task DeleteAsync(EntityByIdFilter filter);

    public abstract Task<TEntityDto> GetAsync(EntityByIdFilter filter);

    public abstract Task<PagedResult<TForListDto>> GetListAsync(TFilter filter);
}