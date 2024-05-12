﻿using System.ServiceModel;
using Sawnet.Blazor.Shared.Grpc.Filters;

namespace Sawnet.Blazor.Shared.Grpc;

[ServiceContract]
public interface ICrudService<TEntityDto, TCreateDto, TForListDto, TFilter>
{
    [OperationContract]
    public Task<TEntityDto> CreateAsync(TCreateDto createDto);

    [OperationContract]
    public Task<TEntityDto> UpdateAsync(TEntityDto dto);

    [OperationContract]
    public Task DeleteAsync(EntityByIdFilter filter);

    [OperationContract]
    public Task<TEntityDto> GetAsync(EntityByIdFilter filter);

    [OperationContract]
    public Task<PagedResult<TForListDto>> GetListAsync(TFilter filter);
}