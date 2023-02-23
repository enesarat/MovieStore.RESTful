using WebApi.Services.Abstract;

namespace WebApi.Services.Concrete
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[Console Logger] - " + message);
        }
    }
}
