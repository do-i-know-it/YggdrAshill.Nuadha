using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Monitorization;
using System;
using System.Runtime.CompilerServices;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions of <see cref="IConsumption{TSignal}"/> for <see cref="Report"/>.
    /// </summary>
    public static class ConsumptionExtensionForReport
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
        public static void Log(this IConsumption<Report> consumption,
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

            Record.Log(consumption, level, message, filePath, lineNumber, memberName);
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
        public static void Log(this IConsumption<Report> consumption,
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
            Record.Log(consumption, level, exception, filePath, lineNumber, memberName);
        }
    }
}
