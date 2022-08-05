using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TSignal}"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public static class WhenMemoryUsageIs
    {
        /// <summary>
        /// When one <see cref="MemoryUsage.TotalSize"/> is same as or more than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IEvaluation<MemoryUsage> Over { get; } = new MemoryUsageIsOver();
        private sealed class MemoryUsageIsOver :
            IEvaluation<MemoryUsage>
        {
            public bool Evaluate(MemoryUsage signal, MemoryUsage gauge)
            {
                return gauge.TotalSize <= signal.TotalSize;
            }
        }

        /// <summary>
        /// When one <see cref="MemoryUsage.TotalSize"/> is same as or less than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IEvaluation<MemoryUsage> Under { get; } = new MemoryUsageIsUnder();
        private sealed class MemoryUsageIsUnder :
            IEvaluation<MemoryUsage>
        {
            public bool Evaluate(MemoryUsage signal, MemoryUsage gauge)
            {
                return signal.TotalSize <= gauge.TotalSize;
            }
        }
    }
}
