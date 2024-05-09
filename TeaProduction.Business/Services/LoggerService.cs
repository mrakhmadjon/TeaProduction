using TeaProduction.Business.Enums;
using TeaProduction.Business.Interfaces;
using SerilogLogger = Serilog;

namespace TeaProduction.Business.Services;

public class LoggerService : ILoggerInterface
{
    public void Log(string message)
    {
        SerilogLogger.Log.Information(message);
    }

    public void Log(string message, LogLevel logLevel)
    {
        if (logLevel == LogLevel.Information)
            SerilogLogger.Log.Information(message);
        else if (logLevel == LogLevel.Error)
            SerilogLogger.Log.Error(message);
        else if (logLevel == LogLevel.Warning)
            SerilogLogger.Log.Warning(message);
    }

    public void Log(string message, int logLevel)
    {
        if (Enum.IsDefined(typeof(LogLevel), logLevel))
        {
            LogLevel parsedLogLevel = (LogLevel)logLevel;
            if (parsedLogLevel == LogLevel.Information)
                SerilogLogger.Log.Information(message);
            else if (parsedLogLevel == LogLevel.Error)
                SerilogLogger.Log.Error(message);
            else if (parsedLogLevel == LogLevel.Warning)
                SerilogLogger.Log.Warning(message);
        }
        else
        {
            throw new ArgumentException("Log level value does not exist");
        }
    }

    public void Log(Exception exception, string message)
    {
        SerilogLogger.Log.Error(exception, message);
    }
}
