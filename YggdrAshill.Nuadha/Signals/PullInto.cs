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
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<Pull, Push> Push(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new PullToPush(notification);
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
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Pull"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Signals.Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<Pull, Touch> Touch(INotification<Pull> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new PullToTouch(notification);
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
