using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class TiltToPull
    {
        public static IConversion<Tilt, Pull> Tilted { get; }
            = new Conversion<Tilt, Pull>(signal =>
            {
                var dotted
                = signal.Horizontal * signal.Horizontal
                + signal.Vertical * signal.Vertical;

                var strength = dotted * 0.5f;

                return new Pull(strength);
            });

        public static IConversion<Tilt, Pull> Up { get; }
            = new Conversion<Tilt, Pull>(signal =>
            {
                var strength = Math.Max(signal.Vertical, 0);

                return new Pull(strength);
            });

        public static IConversion<Tilt, Pull> Down { get; }
            = new Conversion<Tilt, Pull>(signal =>
            {
                var strength = Math.Min(signal.Vertical, 0);
                strength = Math.Abs(strength);

                return new Pull(strength);
            });

        public static IConversion<Tilt, Pull> Right { get; }
            = new Conversion<Tilt, Pull>(signal =>
            {
                var strength = Math.Max(signal.Horizontal, 0);

                return new Pull(strength);
            });

        public static IConversion<Tilt, Pull> Left { get; }
            = new Conversion<Tilt, Pull>(signal =>
            {
                var strength = Math.Min(signal.Horizontal, 0);
                strength = Math.Abs(strength);

                return new Pull(strength);
            });
    }
}
