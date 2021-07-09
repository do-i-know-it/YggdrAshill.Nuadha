using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class TiltToPull :
        IConversion<Tilt, Pull>
    {
        public static TiltToPull Distance { get; }
            = new TiltToPull(signal =>
            {
                return signal.Distance.ToPull();
            });

        public static TiltToPull Right { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(signal.Horizontal, 0).ToPull();
            });

        public static TiltToPull Left { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(-signal.Horizontal, 0).ToPull();
            });

        public static TiltToPull Forward { get; }
            = new TiltToPull(signal =>
            {
                return Math.Max(signal.Vertical, 0).ToPull();
            });

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
