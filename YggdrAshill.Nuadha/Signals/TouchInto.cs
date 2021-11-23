using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class TouchInto
    {
        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Signals.Push"/>.
        /// </summary>
        public static ITranslation<Touch, Push> Push { get; }
            = SignalInto.Signal<Touch, Push>(signal =>
            {
                return signal.ToPush();
            });

        /// <summary>
        /// Converts <see cref="Touch"/> into <see cref="Signals.Pull"/>.
        /// </summary>
        public static ITranslation<Touch, Pull> Pull { get; }
            = SignalInto.Signal<Touch, Pull>(signal =>
            {
                return signal.ToPull();
            });
    }
}
