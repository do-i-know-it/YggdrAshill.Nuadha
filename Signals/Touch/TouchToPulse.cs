using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class TouchToPulse :
        IDetection<Touch>
    {
        public static IDetection<Touch> HasTouched(Touch initial)
        {
            var detection = new TouchToPulse(_ =>
            {
                return false;
            }, signal =>
            {
                return signal == Touch.Enabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Touch> HasEnabled()
            => HasTouched(Touch.Disabled);

        public static IDetection<Touch> IsTouched(Touch initial)
        {
            var detection = new TouchToPulse(signal =>
            {
                return signal == Touch.Enabled;
            }, signal =>
            {
                return signal == Touch.Enabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Touch> IsEnabled()
            => IsTouched(Touch.Disabled);

        public static IDetection<Touch> HasReleased(Touch initial)
        {
            var detection = new TouchToPulse(signal =>
            {
                return signal == Touch.Disabled;
            }, _ =>
            {
                return false;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Touch> HasDisabled()
            => HasReleased(Touch.Disabled);

        public static IDetection<Touch> IsReleased(Touch initial)
        {
            var detection = new TouchToPulse(signal =>
            {
                return signal == Touch.Disabled;
            }, signal =>
            {
                return signal == Touch.Disabled;
            });

            detection.previous = initial;

            return detection;
        }
        public static IDetection<Touch> IsDisabled()
            => IsReleased(Touch.Disabled);

        private Touch previous;

        private readonly Func<Touch, bool> onTouched;

        private readonly Func<Touch, bool> onReleased;

        private TouchToPulse(Func<Touch, bool> onTouched, Func<Touch, bool> onReleased)
        {
            this.onTouched = onTouched;

            this.onReleased = onReleased;
        }

        public bool Detect(Touch signal)
        {
            var isTouched = previous == Touch.Enabled;

            previous = signal;

            if (isTouched)
            {
                return onTouched.Invoke(signal);
            }
            else
            {
                return onReleased.Invoke(signal);
            }
        }
    }
}
