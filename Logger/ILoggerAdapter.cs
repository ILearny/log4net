using Logger.Models;

namespace Logger
{
    public interface ILoggerAdapter
    {
        void Log(LogEntry entry);
    }
}
