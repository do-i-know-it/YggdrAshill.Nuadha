using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Button"/>.
    /// </summary>
    public static class FromButton
    {
        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Touch"/>.
        /// </summary>
        public static IConversion<Button, Touch> IntoTouch { get; } = From<Button>.Into<Touch>.Like(signal => signal.Touch);

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Push"/>.
        /// </summary>
        public static IConversion<Button, Push> IntoPush { get; } = From<Button>.Into<Push>.Like(signal => signal.Push);

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Trigger"/>.
        /// </summary>
        public static IConversion<Button, Trigger> IntoTrigger { get; } = From<Button>.Into<Trigger>.Like(signal => (Trigger)signal);
    }
}
