using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> to operate <see cref="INotification{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notify.
    /// </typeparam>
    public static class Notify<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Inverts <see cref="INotification{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notify.
        /// </typeparam>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> to invert.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> inverted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<TSignal> Inverted(INotification<TSignal> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new NotifyInverted(notification);
        }
        private sealed class NotifyInverted:
            INotification<TSignal>
        {
            private readonly INotification<TSignal> notification;

            internal NotifyInverted(INotification<TSignal> notification)
            {
                this.notification = notification;
            }

            public bool Notify(TSignal signal)
            {
                return !notification.Notify(signal);
            }
        }

        /// <summary>
        /// Multiplies two <see cref="INotification{TSignal}"/>s.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notify.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="INotification{TSignal}"/> to multiply.
        /// </param>
        /// <param name="second">
        /// <see cref="INotification{TSignal}"/> to multiply.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> multiplied.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static INotification<TSignal> Multiplied(INotification<TSignal> first, INotification<TSignal> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new NotifyMultiplied(first, second);
        }
        private sealed class NotifyMultiplied:
            INotification<TSignal>
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal NotifyMultiplied(INotification<TSignal> first, INotification<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool Notify(TSignal signal)
            {
                return first.Notify(signal) && second.Notify(signal);
            }
        }

        /// <summary>
        /// Adds two <see cref="INotification{TSignal}"/>s.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notify.
        /// </typeparam>
        /// <param name="first">
        /// <see cref="INotification{TSignal}"/> to add.
        /// </param>
        /// <param name="second">
        /// <see cref="INotification{TSignal}"/> to add.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="second"/> is null.
        /// </exception>
        public static INotification<TSignal> Added(INotification<TSignal> first, INotification<TSignal> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new NotifyAdded(first, second);
        }
        private sealed class NotifyAdded :
            INotification<TSignal>
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal NotifyAdded(INotification<TSignal> first, INotification<TSignal> second)
            {
                this.first = first;

                this.second = second;
            }

            public bool Notify(TSignal signal)
            {
                return first.Notify(signal) || second.Notify(signal);
            }
        }
    }
}
