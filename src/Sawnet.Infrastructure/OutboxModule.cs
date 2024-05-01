using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Sawnet.Infrastructure.BackgroundJobs;
using Sawnet.Shared.Modules;

namespace Sawnet.Infrastructure;

public sealed class OutboxModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddQuartz(configurator =>
        {
            var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

            configurator
                .AddJob<ProcessOutboxMessagesJob>(jobKey)
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSimpleSchedule(schedule =>
                            schedule
                                .WithIntervalInSeconds(100000)
                                .RepeatForever()));
        });

        services.AddQuartzHostedService();
        services.AddTransient<OutboxMessageStore>();
        services.AddTransient<ProcessOutboxMessagesJob>();
    }
}