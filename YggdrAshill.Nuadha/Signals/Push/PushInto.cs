using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public static class PushInto
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Push, Touch> Touch { get; }
            = SignalInto.Signal<Push, Touch>(signal =>
            {
                return signal.ToTouch();
            });

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Pull"/>.
        /// </summary>
        public static ITranslation<Push, Pull> Pull { get; }
            = SignalInto.Signal<Push, Pull>(signal =>
            {
                return signal.ToPull();
            });
    }
}
