namespace TeaProduction.Business.NewLoggerService
{
    public class WarningLogger : LoggerAbstract
    {
        public override void Log(string message)
        {
            Console.WriteLine($"This is a Warning message {message}");
        }
    }
}
