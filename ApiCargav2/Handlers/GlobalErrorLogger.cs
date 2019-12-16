using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ApiCargav2.Handlers
{
    public class GlobalErrorLogger : ExceptionLogger
    {
        public static ILogger logger;
        public GlobalErrorLogger()
        {
            string pathLog = ConfigurationManager.AppSettings["PathLog"];
            logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.ColoredConsole()
                            .WriteTo.Map(evt => evt.Level, (level, wt) => wt.File(new CompactJsonFormatter(), $@"{pathLog}{level}\{DateTime.Now.ToString("yyyy")}\{DateTime.Now.ToString("MM")}\log-{DateTime.Now:yyyy-MM-dd}.log", rollingInterval: RollingInterval.Day))
                            .AuditTo.File($@"{pathLog}audit_{DateTime.Now:yyyy-MM-dd}.log")
                            .CreateLogger();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var exception = context.Exception;
            // Write your custom logging code here
            logger.Error(exception, "Exception Error");
        }
    }
}