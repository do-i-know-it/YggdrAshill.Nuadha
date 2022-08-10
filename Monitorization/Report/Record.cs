using YggdrAshill.Nuadha.Signalization;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Records <see cref="Report"/> with <see cref="IConsumption{TSignal}"/> for <see cref="Report"/>.
    /// </summary>
    public static class Record
    {
        /// <summary>
        /// Records <see cref="Report"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TValue}"/> to record <see cref="Report"/>.
        /// </param>
        /// <param name="level">
        /// <see cref="Report.Severity"/> for <see cref="Report.Level"/>.
        /// </param>
        /// <param name="message">
        /// <see cref="string"/> for <see cref="Report.Message"/>.
        /// </param>
        /// <param name="filePath">
        /// <see cref="string"/> for <see cref="Report.FilePath"/>.
        /// </param>
        /// <param name="lineNumber">
        /// <see cref="int"/> for <see cref="Report.LineNumber"/>.
        /// </param>
        /// <param name="memberName">
        /// <see cref="string"/> for <see cref="Report.MemberName"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="message"/> is null.
        /// </exception>
        public static void Log(IConsumption<Report> consumption,
            Report.Severity level, string message,
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

            consumption.Log(level, message, stackTrace, filePath, lineNumber, memberName);
        }

        /// <summary>
        /// Records <see cref="Report"/>.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TValue}"/> to record <see cref="Report"/>.
        /// </param>
        /// <param name="level">
        /// <see cref="Report.Severity"/> for <see cref="Report.Level"/>.
        /// </param>
        /// <param name="exception">
        /// <see cref="Exception"/> for <see cref="Report.Message"/>.
        /// </param>
        /// <param name="filePath">
        /// <see cref="string"/> for <see cref="Report.FilePath"/>.
        /// </param>
        /// <param name="lineNumber">
        /// <see cref="int"/> for <see cref="Report.LineNumber"/>.
        /// </param>
        /// <param name="memberName">
        /// <see cref="string"/> for <see cref="Report.MemberName"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="exception"/> is null.
        /// </exception>
        public static void Log(IConsumption<Report> consumption,
            Report.Severity level, Exception exception,
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

            var message = $"{exception}";
            var stackTrace = exception.StackTrace;

            consumption.Log(level, message, stackTrace, filePath, lineNumber, memberName);
        }

        private static void Log(this IConsumption<Report> consumption,
            Report.Severity level, string message, string stackTrace,
            string filePath, int lineNumber, string memberName)
        {
            var dateTime = DateTime.Now;
            var thread = Thread.CurrentThread.ManagedThreadId;

            var log = new Report(level, dateTime, message, stackTrace, thread, filePath, lineNumber, memberName);

            consumption.Consume(log);
        }
    }
}
