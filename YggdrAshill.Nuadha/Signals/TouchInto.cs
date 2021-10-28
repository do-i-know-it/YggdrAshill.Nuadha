using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Touch"/>
    /// </summary>
    public static class TouchInto
    {
        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Signals.Push"/>.
        /// </summary>
        public static ITranslation<Touch, Push> Push { get; } = SignalIntoSignal.Signal<Touch, Push>(signal => signal.ToBoolean().ToPush());

        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        public static ITranslation<Touch, Pulse> Pulse { get; } = PulseOf.Signal(TouchIs.Enabled);
    }
}
