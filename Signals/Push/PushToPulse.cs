using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PushToPulse :
        IDetection<Push>
    {
        public static IDetection<Push> HasPushed(Push initial)
        {
            var detection = new PushToPulse(_ =>
            {
                return false;
            }, signal =>
            {
                return signal == Push.Enabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Push> HasEnabled()
            => HasPushed(Push.Disabled);

        public static IDetection<Push> IsPushed(Push initial)
        {
            var detection = new PushToPulse(signal =>
            {
                return signal == Push.Enabled;
            }, signal =>
            {
                return signal == Push.Enabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Push> IsEnabled()
            => IsPushed(Push.Disabled);

        public static IDetection<Push> HasReleased(Push initial)
        {
            var detection = new PushToPulse(signal =>
            {
                return signal == Push.Disabled;
            }, _ =>
            {
                return false;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Push> HasDisabled()
            => HasReleased(Push.Disabled);

        public static IDetection<Push> IsReleased(Push initial)
        {
            var detection = new PushToPulse(signal =>
            {
                return signal == Push.Disabled;
            }, signal =>
            {
                return signal == Push.Disabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Push> IsDisabled()
            => IsReleased(Push.Disabled);

        private Push previous;

        private readonly Func<Push, bool> onPushed;

        private readonly Func<Push, bool> onReleased;

        private PushToPulse(Func<Push, bool> onPushed, Func<Push, bool> onReleased)
        {
            this.onPushed = onPushed;

            this.onReleased = onReleased;
        }

        public bool Detect(Push signal)
        {
            var isPushed = previous == Push.Enabled;

            previous = signal;

            if (isPushed)
            {
                return onPushed.Invoke(signal);
            }
            else
            {
                return onReleased.Invoke(signal);
            }
        }
    }
}
