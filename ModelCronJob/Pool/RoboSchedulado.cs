using Microsoft.Extensions.Logging;
using ModelCronJob.Pool.Base;
using ModelCronJob.Pool.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModelCronJob.Pool
{
    public class RoboSchedulado : CronJob
    {
            private readonly ILogger<RoboSchedulado> _logger;

            public RoboSchedulado(IScheduleConfig<RoboSchedulado> config, ILogger<RoboSchedulado> logger)
                : base(config.CronExpression, config.TimeZoneInfo)
            {
                _logger = logger;
            }

            public override Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("CronJob starts.");
                return base.StartAsync(cancellationToken);
            }

            public override Task DoWork(CancellationToken cancellationToken)
            {
                _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob is working.");
                return Task.CompletedTask;
            }

            public override Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("CronJob is stopping.");
                return base.StopAsync(cancellationToken);
            }
    }
}
