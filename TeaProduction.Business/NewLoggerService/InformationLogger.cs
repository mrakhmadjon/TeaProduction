namespace TeaProduction.Business.NewLoggerService
{
    public class InformationLogger : LoggerAbstract
    {
        public override void Log(string message)
        {
            Console.WriteLine($"This is a Information message {message}");
        }
    }
}
