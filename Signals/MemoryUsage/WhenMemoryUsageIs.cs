using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public static class WhenMemoryUsageIs
    {
        /// <summary>
        /// When one <see cref="MemoryUsage.TotalSize"/> is same as or more than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static INotification<Analysis<MemoryUsage>> Over { get; } = new MemoryUsageIsOver();
        private sealed class MemoryUsageIsOver :
            INotification<Analysis<MemoryUsage>>
        {
            public bool Notify(Analysis<MemoryUsage> signal)
            {
                return signal.Expected.TotalSize <= signal.Actual.TotalSize;
            }
        }

        /// <summary>
        /// When one <see cref="MemoryUsage.TotalSize"/> is same as or less than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static INotification<Analysis<MemoryUsage>> Under { get; } = new MemoryUsageIsUnder();
        private sealed class MemoryUsageIsUnder :
            INotification<Analysis<MemoryUsage>>
        {
            public bool Notify(Analysis<MemoryUsage> signal)
            {
                return signal.Actual.TotalSize <= signal.Expected.TotalSize;
            }
        }
    }
}
