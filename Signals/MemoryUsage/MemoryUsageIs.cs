using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public static class MemoryUsageIs
    {
        /// <summary>
        /// When one <see cref="MemoryUsage"/> is equal to another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> EqualTo { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Expected.Total == signal.Actual.Total);

        /// <summary>
        /// When one <see cref="MemoryUsage"/> is equal to another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> NotEqualTo { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Expected.Total != signal.Actual.Total);

        /// <summary>
        /// When one <see cref="MemoryUsage"/> is more than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> MoreThan { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Expected.Total < signal.Actual.Total);

        /// <summary>
        /// When one <see cref="MemoryUsage"/> is less than another <see cref="MemoryUsage"/>.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> LessThan { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Actual.Total < signal.Expected.Total);

        /// <summary>
        /// When one <see cref="MemoryUsage"/> is another <see cref="MemoryUsage"/> or more.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> Over { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Expected.Total <= signal.Actual.Total);

        /// <summary>
        /// When one <see cref="MemoryUsage"/> is another <see cref="MemoryUsage"/> or less.
        /// </summary>
        public static IDetection<Analysis<MemoryUsage>> Under { get; } = That<Analysis<MemoryUsage>>.Is(signal => signal.Actual.Total <= signal.Expected.Total);
    }
}
