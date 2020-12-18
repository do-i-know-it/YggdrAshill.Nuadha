using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class TiltToPull :
        IConversion<Tilt, Pull>
    {
        public static IConversion<Tilt, Pull> Up { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(signal.Vertical, 0));
            });

        public static IConversion<Tilt, Pull> Down { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(-signal.Vertical, 0));
            });

        public static IConversion<Tilt, Pull> Right { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(signal.Horizontal, 0));
            });

        public static IConversion<Tilt, Pull> Left { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(-signal.Horizontal, 0));
            });

        private readonly Func<Tilt, Pull> onConverted;

        private TiltToPull(Func<Tilt, Pull> onConverted)
        {
            this.onConverted = onConverted;
        }

        public Pull Convert(Tilt signal)
        {
            return onConverted.Invoke(signal);
        }
    }
}
