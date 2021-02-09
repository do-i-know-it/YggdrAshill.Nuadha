using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class TiltToPull :
        ITranslation<Tilt, Pull>
    {
        public static ITranslation<Tilt, Pull> Up { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(signal.Vertical, 0));
            });

        public static ITranslation<Tilt, Pull> Down { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(-signal.Vertical, 0));
            });

        public static ITranslation<Tilt, Pull> Right { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(signal.Horizontal, 0));
            });

        public static ITranslation<Tilt, Pull> Left { get; }
            = new TiltToPull(signal =>
            {
                return new Pull(Math.Max(-signal.Horizontal, 0));
            });

        private readonly Func<Tilt, Pull> onTranslated;

        private TiltToPull(Func<Tilt, Pull> onTranslated)
        {
            this.onTranslated = onTranslated;
        }

        public Pull Translate(Tilt signal)
        {
            return onTranslated.Invoke(signal);
        }
    }
}
