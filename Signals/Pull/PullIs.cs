using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class PullIs
    {
        /// <summary>
        /// When one <see cref="Pull"/> is equal to another <see cref="Pull"/>.
        /// </summary>
        public static IDetection<Analysis<Pull>> EqualTo { get; } = That<Analysis<Pull>>.Is(signal => signal.Expected == signal.Actual);

        /// <summary>
        /// When one <see cref="Pull"/> is equal to another <see cref="Pull"/>.
        /// </summary>
        public static IDetection<Analysis<Pull>> NotEqualTo { get; } = That<Analysis<Pull>>.Is(signal => signal.Expected != signal.Actual);

        /// <summary>
        /// When one <see cref="Pull"/> is more than another <see cref="Pull"/>.
        /// </summary>
        public static IDetection<Analysis<Pull>> MoreThan { get; } = That<Analysis<Pull>>.Is(signal => signal.Expected < signal.Actual);

        /// <summary>
        /// When one <see cref="Pull"/> is less than another <see cref="Pull"/>.
        /// </summary>
        public static IDetection<Analysis<Pull>> LessThan { get; } = That<Analysis<Pull>>.Is(signal => signal.Actual < signal.Expected);

        /// <summary>
        /// When one <see cref="Pull"/> is another <see cref="Pull"/> or more.
        /// </summary>
        public static IDetection<Analysis<Pull>> Over { get; } = That<Analysis<Pull>>.Is(signal => signal.Expected <= signal.Actual);

        /// <summary>
        /// When one <see cref="Pull"/> is another <see cref="Pull"/> or less.
        /// </summary>
        public static IDetection<Analysis<Pull>> Under { get; } = That<Analysis<Pull>>.Is(signal => signal.Actual <= signal.Expected);
    }
}
