using Serilog;
using Serilog.Events;
using System.Runtime.CompilerServices;

namespace MockInterview.API.LogConfig
{
    public static class LogConfigurations
    {
        public static LoggerConfiguration SetLogConfiguration()
        {
            return new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("LogFiles/log.txt",
             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
             rollingInterval: RollingInterval.Day,
             restrictedToMinimumLevel: LogEventLevel.Warning
             );
        }
    }
}
