using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class PullIs
    {
        public static INotification<Pull> Disabled(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new Notification(threshold, false);
        }

        public static INotification<Pull> Enabled(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new Notification(threshold, true);
        }

        private sealed class Notification :
            INotification<Pull>
        {
            private readonly HysteresisThreshold threshold;

            private readonly bool straight;

            private bool previous = false;

            internal Notification(HysteresisThreshold threshold, bool straight)
            {
                this.threshold = threshold;

                this.straight = straight;
            }

            public bool Notify(Pull signal)
            {
                if (previous)
                {
                    previous = threshold.Lower <= (float)signal;
                }
                else
                {
                    previous = threshold.Upper <= (float)signal;
                }

                return straight ? previous : !previous;
            }
        }
    }
}
