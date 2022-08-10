using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class BatteryIs
    {
        /// <summary>
        /// When one <see cref="Battery"/> is equal to another <see cref="Battery"/>.
        /// </summary>
        public static IDetection<Analysis<Battery>> EqualTo { get; } = That<Analysis<Battery>>.Is(signal => signal.Expected == signal.Actual);

        /// <summary>
        /// When one <see cref="Battery"/> is equal to another <see cref="Battery"/>.
        /// </summary>
        public static IDetection<Analysis<Battery>> NotEqualTo { get; } = That<Analysis<Battery>>.Is(signal => signal.Expected != signal.Actual);

        /// <summary>
        /// When one <see cref="Battery"/> is more than another <see cref="Battery"/>.
        /// </summary>
        public static IDetection<Analysis<Battery>> MoreThan { get; } = That<Analysis<Battery>>.Is(signal => signal.Expected < signal.Actual);

        /// <summary>
        /// When one <see cref="Battery"/> is less than another <see cref="Battery"/>.
        /// </summary>
        public static IDetection<Analysis<Battery>> LessThan { get; } = That<Analysis<Battery>>.Is(signal => signal.Actual < signal.Expected);

        /// <summary>
        /// When one <see cref="Battery"/> is another <see cref="Battery"/> or more.
        /// </summary>
        public static IDetection<Analysis<Battery>> Over { get; } = That<Analysis<Battery>>.Is(signal => signal.Expected <= signal.Actual);

        /// <summary>
        /// When one <see cref="Battery"/> is another <see cref="Battery"/> or less.
        /// </summary>
        public static IDetection<Analysis<Battery>> Under { get; } = That<Analysis<Battery>>.Is(signal => signal.Actual <= signal.Expected);
    }
}
