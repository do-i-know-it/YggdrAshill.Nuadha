using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class PullIs
    {
        /// <summary>
        /// Notifies <see cref="Pull"/> is under <see cref="HysteresisThreshold"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to notify.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static INotification<Pull> Under(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new Notification(threshold, false);
        }

        /// <summary>
        /// Notifies <see cref="Pull"/> is over <see cref="HysteresisThreshold"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to notify.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static INotification<Pull> Over(HysteresisThreshold threshold)
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
