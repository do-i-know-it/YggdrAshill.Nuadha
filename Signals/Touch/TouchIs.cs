using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <see cref="Touch"/>.
    /// </summary>
    public static class TouchIs
    {
        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        public static IDetection<Touch> Enabled { get; } = That<Touch>.Is(signal => (bool)signal);

        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        public static IDetection<Touch> Disabled { get; } = That<Touch>.Is(signal => !(bool)signal);

        /// <summary>
        /// When one <see cref="Touch"/> is equal to another <see cref="Touch"/>.
        /// </summary>
        public static IDetection<Analysis<Touch>> EqualTo { get; } = That<Analysis<Touch>>.Is(signal => signal.Expected == signal.Actual);

        /// <summary>
        /// When one <see cref="Touch"/> is not equal to another <see cref="Touch"/>.
        /// </summary>
        public static IDetection<Analysis<Touch>> NotEqualTo { get; } = That<Analysis<Touch>>.Is(signal => signal.Expected != signal.Actual);
    }
}
