using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class PullInto
    {
        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITranslation<Pull, Push> Push(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PullToPush(PullIs.Enabled(threshold));
        }
        private sealed class PullToPush :
            ITranslation<Pull, Push>
        {
            private readonly INotification<Pull> notification;

            internal PullToPush(INotification<Pull> notification)
            {
                this.notification = notification;
            }

            public Push Translate(Pull signal)
            {
                return notification.Notify(signal).ToPush();
            }
        }

        /// <summary>
        /// Converts <see cref="Pull"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITranslation<Pull, Touch> Touch(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PullToTouch(PullIs.Enabled(threshold));
        }
        private sealed class PullToTouch :
            ITranslation<Pull, Touch>
        {
            private readonly INotification<Pull> notification;

            internal PullToTouch(INotification<Pull> notification)
            {
                this.notification = notification;
            }

            public Touch Translate(Pull signal)
            {
                return notification.Notify(signal).ToTouch();
            }
        }
    }
}
