using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Touch"/>
    /// </summary>
    public static class TouchInto
    {
        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Signals.Push"/>.
        /// </summary>
        public static IConversion<Touch, Push> Push { get; } = SignalInto.Signal<Touch, Push>(signal => signal.ToBoolean().ToPush());

        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        public static IConversion<Touch, Pulse> Pulse { get; } = PulseFrom.Signal(TouchIs.Enabled);
    }
}
