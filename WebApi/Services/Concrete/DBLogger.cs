using WebApi.Services.Abstract;

namespace WebApi.Services.Concrete
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DB Logger] - " + message);
        }
    }
}
