using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Trigger"/>.
    /// </summary>
    public static class FromTrigger
    {
        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Touch"/>.
        /// </summary>
        public static IConversion<Trigger, Touch> IntoTouch { get; } = From<Trigger>.Into<Touch>.Like(signal => signal.Touch);

        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Pull"/>.
        /// </summary>
        public static IConversion<Trigger, Pull> IntoPull { get; } = From<Trigger>.Into<Pull>.Like(signal => signal.Pull);
    }
}
