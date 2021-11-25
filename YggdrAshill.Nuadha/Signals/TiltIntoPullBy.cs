using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
    /// </summary>
    public static class TiltIntoPullBy
    {
        /// <summary>
        /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Tilt, Pull> Distance { get; }
            = SignalInto.Signal<Tilt, Pull>(signal =>
            {
                return signal.Distance.ToPull();
            });

        /// <summary>
        /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Tilt, Pull> Left { get; }
            = SignalInto.Signal<Tilt, Pull>(signal =>
            {
                return Math.Max(-signal.Horizontal, 0).ToPull();
            });

        /// <summary>
        /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Tilt, Pull> Right { get; }
            = SignalInto.Signal<Tilt, Pull>(signal =>
            {
                return Math.Max(signal.Horizontal, 0).ToPull();
            });

        /// <summary>
        /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Tilt, Pull> Forward { get; }
            = SignalInto.Signal<Tilt, Pull>(signal =>
            {
                return Math.Max(signal.Vertical, 0).ToPull();
            });

        /// <summary>
        /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Tilt, Pull> Backward { get; }
            = SignalInto.Signal<Tilt, Pull>(signal =>
            {
                return Math.Max(-signal.Vertical, 0).ToPull();
            });
    }
}
