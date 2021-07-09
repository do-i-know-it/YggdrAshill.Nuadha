using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Converts <see cref="Tilt"/> into <see cref="Pull"/>.
    /// </summary>
    public sealed class TiltToPull :
        IConversion<Tilt, Pull>
    {
        /// <summary>
        /// Distance of <see cref="Tilt"/>.
        /// </summary>
        public static TiltToPull Distance { get; }
            = new TiltToPull(signal =>
            {
                return signal.Distance.ToPull();
            });

        /// <summary>
        /// Right side of <see cref="Tilt"/>.
        /// </summary>
        public static TiltToPull Right { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(signal.Horizontal, 0).ToPull();
            });

        /// <summary>
        /// Left side of <see cref="Tilt"/>.
        /// </summary>
        public static TiltToPull Left { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(-signal.Horizontal, 0).ToPull();
            });

        /// <summary>
        /// Forward side of <see cref="Tilt"/>.
        /// </summary>
        public static TiltToPull Forward { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(signal.Vertical, 0).ToPull();
            });

        /// <summary>
        /// Backward side of <see cref="Tilt"/>.
        /// </summary>
        public static TiltToPull Backward { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(-signal.Vertical, 0).ToPull();
            });

        private readonly Func<Tilt, Pull> onConverted;

        private TiltToPull(Func<Tilt, Pull> onConverted)
        {
            this.onConverted = onConverted;
        }

        /// <inheritdoc/>
        public Pull Convert(Tilt signal)
        {
            return onConverted.Invoke(signal);
        }
    }
}
