using YggdrAshill.Nuadha.Signalization;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Nuadha.Historization
{
    public static class HistorizationExtension
    {
        private static void Log(this IConsumption<Log> consumption, SeverityLevel severity, string message, string stackTrace,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            var dateTime = DateTime.Now;
            var thread = Thread.CurrentThread.ManagedThreadId;

            var log = new Log(severity, dateTime, message, stackTrace, thread, filePath, lineNumber, memberName);

            consumption.Consume(log);
        }

        public static void Log(this IConsumption<Log> consumption, SeverityLevel severity, string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var stackTrace = Environment.StackTrace;

            consumption.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }

        public static void Log(this IConsumption<Log> consumption, SeverityLevel severity, Exception exception,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var message = exception.ToString();
            var stackTrace = exception.StackTrace;

            consumption.Log(severity, message, stackTrace, filePath, lineNumber, memberName);
        }
    }
}
