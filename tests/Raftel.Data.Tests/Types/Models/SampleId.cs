﻿using Raftel.Core.BaseTypes;

namespace Raftel.Data.Tests.Types.Models;

public record SampleId : EntityId
{ 
    
    public static SampleId Create(Guid value)
    {
        return new SampleId { Value = value };
    }

    public static explicit operator SampleId(Guid id) => Create(id);

    public static implicit operator Guid(SampleId id) => id.Value;
} 