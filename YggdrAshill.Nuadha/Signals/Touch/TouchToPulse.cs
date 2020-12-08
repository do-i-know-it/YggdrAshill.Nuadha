using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class TouchToPulse
    {
        public static IPulsation<Touch> HasTouched { get; }
            = new Pulsation<Touch>((previous, current) =>
            {
                return previous == Touch.Disabled && current == Touch.Enabled;
            });

        public static IPulsation<Touch> IsTouched { get; }
            = new Pulsation<Touch>((previous, current) =>
            {
                return previous == Touch.Enabled && current == Touch.Enabled;
            });

        public static IPulsation<Touch> HasReleased { get; }
            = new Pulsation<Touch>((previous, current) =>
            {
                return previous == Touch.Enabled && current == Touch.Disabled;
            });

        public static IPulsation<Touch> IsReleased { get; }
            = new Pulsation<Touch>((previous, current) =>
            {
                return previous == Touch.Disabled && current == Touch.Disabled;
            });
    }
}
