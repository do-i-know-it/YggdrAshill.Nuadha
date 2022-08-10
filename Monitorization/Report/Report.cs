using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for report.
    /// </summary>
    public struct Report :
        ISignal
    {
        [Flags]
        public enum Severity : byte
        {
            None = 0,
            Trace = 1 << 0,
            Notification = 1 << 1,
            Assertion = 1 << 2,
            Information = 1 << 3,
            Warning = 1 << 4,
            Error = 1 << 5,
            Fatal = 1 << 6,
        }

        /// <summary>
        /// <see cref="Severity"/> for level of <see cref="Report"/>.
        /// </summary>
        public Severity Level { get; }

        /// <summary>
        /// <see cref="System.DateTime"/> for time of <see cref="Report"/>.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// <see cref="string"/> for message of <see cref="Report"/>.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// <see cref="string"/> for stack trace of <see cref="Report"/>.
        /// </summary>
        public string StackTrace { get; }

        /// <summary>
        /// <see cref="int"/> for thread number of <see cref="Report"/>.
        /// </summary>
        public int Thread { get; }

        /// <summary>
        /// <see cref="string"/> for file path of <see cref="Report"/>.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// <see cref="int"/> for line number of <see cref="Report"/>.
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// <see cref="string"/> for member name of <see cref="Report"/>.
        /// </summary>
        public string MemberName { get; }

        internal Report(Severity level, DateTime dateTime, string message, string stackTrace, int thread, string filePath, int lineNumber, string memberName)
        {
            Level = level;

            Message = message;

            StackTrace = stackTrace;

            DateTime = dateTime;

            Thread = thread;

            FilePath = filePath;

            LineNumber = lineNumber;

            MemberName = memberName;
        }
    }
}
