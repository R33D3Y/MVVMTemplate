using System.Diagnostics;

namespace MVVMTemplate.Logging
{
    /// <summary>
    /// Implements the <see cref="ILoggingService"/> interface to provide basic logging functionality.
    /// Outputs log messages to the console and the debug window.
    /// </summary>
    public class LoggingService : ILoggingService
    {
        /// <inheritdoc />
        public void Log(string message)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }
    }
}