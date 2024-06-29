using Raftel.Application.Cqrs.Commands;
using Raftel.Application.Cqrs.Queries;
using Raftel.Blazor.Shared.Grpc;
using Raftel.Blazor.Shared.Grpc.Filters;

namespace Raftel.Server.Grpc;

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