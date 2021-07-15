using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Push"/>
    /// </summary>
    public static class PushInto
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static IConversion<Push, Touch> Touch { get; } = SignalInto.Signal<Push, Touch>(signal => signal.ToBoolean().ToTouch());

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Transformation.Pulse"/>.
        /// </summary>
        public static IConversion<Push, Pulse> Pulse { get; } = PulseFrom.Signal(PushIs.Enabled);
    }
}
