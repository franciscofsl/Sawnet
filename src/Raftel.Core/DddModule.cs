﻿using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Raftel.Core.Events;
using Raftel.Core.BaseTypes;
using Raftel.Shared.Modules;

[assembly: InternalsVisibleTo("Raftel.Core.Tests")]

namespace Raftel.Core;

public class DddModule : RaftelModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
    }
}