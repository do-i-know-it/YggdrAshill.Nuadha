using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>
    /// </summary>
    public static class PushInto
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Push, Touch> Touch { get; } = SignalIntoSignal.Signal<Push, Touch>(signal => signal.ToBoolean().ToTouch());

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        public static ITranslation<Push, Pulse> Pulse { get; } = PulseOf.Signal(PushIs.Enabled);
    }
}
