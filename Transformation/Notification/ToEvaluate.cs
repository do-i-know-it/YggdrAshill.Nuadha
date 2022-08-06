using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notify.
    /// </typeparam>
    public static class ToEvaluate<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// When <typeparamref name="TSignal"/> is evaluated.
        /// </summary>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <see cref="Analysis{TSignal}"/> of <typeparamref name="TSignal"/> to notify.
        /// </param>
        /// <param name="threshold">
        /// <see cref="IThreshold{TSignal}"/> for <typeparamref name="TSignal"/> to notify.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static INotification<TSignal> With(INotification<Analysis<TSignal>> notification, IThreshold<TSignal> threshold)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new NotifyToEvaluate(threshold, notification);
        }
        private sealed class NotifyToEvaluate :
            INotification<TSignal>
        {
            private readonly IThreshold<TSignal> threshold;

            private readonly INotification<Analysis<TSignal>> notification;

            internal NotifyToEvaluate(IThreshold<TSignal> threshold, INotification<Analysis<TSignal>> notification)
            {
                this.threshold = threshold;

                this.notification = notification;
            }

            public  bool Notify(TSignal signal)
            {
                return notification.Notify(new Analysis<TSignal>(threshold.Signal, signal));
            }
        }
    }
}
