using TeaProduction.Business.Enums;

namespace TeaProduction.Business.Interfaces;

public interface ILoggerInterface
{
    public void Log(string message);
    public void Log(string message, LogLevel logLevel);
    public void Log(string message, int logLevel);
    public void Log(Exception exception, string message);
}
