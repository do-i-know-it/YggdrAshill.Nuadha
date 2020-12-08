using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class PushToPulse
    {
        public static IPulsation<Push> HasPushed { get; }
            = new Pulsation<Push>((previous, current) =>
            {
                return previous == Push.Disabled && current == Push.Enabled;
            });

        public static IPulsation<Push> IsPushed { get; }
            = new Pulsation<Push>((previous, current) =>
            {
                return previous == Push.Enabled && current == Push.Enabled;
            });

        public static IPulsation<Push> HasReleased { get; }
            = new Pulsation<Push>((previous, current) =>
            {
                return previous == Push.Enabled && current == Push.Disabled;
            });

        public static IPulsation<Push> IsReleased { get; }
            = new Pulsation<Push>((previous, current) =>
            {
                return previous == Push.Disabled && current == Push.Disabled;
            });
    }
}
