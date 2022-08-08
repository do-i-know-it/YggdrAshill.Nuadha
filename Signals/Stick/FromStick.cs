using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Stick"/>.
    /// </summary>
    public static class FromStick
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Touch"/>.
        /// </summary>
        public static IConversion<Stick, Touch> IntoTouch { get; } = From<Stick>.Into<Touch>.Like(signal => signal.Touch);

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Push"/>.
        /// </summary>
        public static IConversion<Stick, Push> IntoPush { get; } = From<Stick>.Into<Push>.Like(signal => signal.Push);

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Tilt"/>.
        /// </summary>
        public static IConversion<Stick, Tilt> IntoTilt { get; } = From<Stick>.Into<Tilt>.Like(signal => signal.Tilt);
    }
}
