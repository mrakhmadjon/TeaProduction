namespace TeaProduction.Business.NewLoggerService
{
    public abstract class LoggerAbstract
    {
        public virtual void Log(string message)
        {
            Console.WriteLine($"This is a default message : {message}");
        }
    }
}
