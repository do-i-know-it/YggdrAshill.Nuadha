using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IDetection{TSignal}"/> for <see cref="Push"/>.
    /// </summary>
    public static class PushIs
    {
        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        public static IDetection<Push> Enabled { get; } = That<Push>.Is(signal => (bool)signal);

        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        public static IDetection<Push> Disabled { get; } = That<Push>.Is(signal => !(bool)signal);

        /// <summary>
        /// When one <see cref="Push"/> is equal to another <see cref="Push"/>.
        /// </summary>
        public static IDetection<Analysis<Push>> EqualTo { get; } = That<Analysis<Push>>.Is(signal => signal.Expected == signal.Actual);

        /// <summary>
        /// When one <see cref="Push"/> is not equal to another <see cref="Push"/>.
        /// </summary>
        public static IDetection<Analysis<Push>> NotEqualTo { get; } = That<Analysis<Push>>.Is(signal => signal.Expected != signal.Actual);
    }
}
