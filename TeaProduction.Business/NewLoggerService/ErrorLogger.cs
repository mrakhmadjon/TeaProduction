namespace TeaProduction.Business.NewLoggerService
{
    public class ErrorLogger : LoggerAbstract
    {
        public override void Log(string message)
        {
            Console.WriteLine($"This is a Error message {message}");
        }
    }
}
