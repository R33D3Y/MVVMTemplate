namespace MVVMTemplate.Logging
{
    /// <summary>
    /// Provides logging functionality for application-wide logging operations.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Logs a specified message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Log(string message);
    }
}