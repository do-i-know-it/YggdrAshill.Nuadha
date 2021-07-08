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
                return (Pull)signal.Distance;
            });

        public static TiltToPull Right { get; }
            = new TiltToPull(signal =>
            {
                return (Pull)Math.Max(signal.Horizontal, 0);
            });

        public static TiltToPull Left { get; }
            = new TiltToPull(signal =>
            {
                return (Pull)(Math.Max(-signal.Horizontal, 0));
            });

        public static TiltToPull Upward { get; }
            = new TiltToPull(signal =>
            {
                return (Pull)Math.Max(signal.Vertical, 0);
            });

        public static TiltToPull Downward { get; }
            = new TiltToPull(signal =>
            {
                return (Pull)Math.Max(-signal.Vertical, 0);
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
