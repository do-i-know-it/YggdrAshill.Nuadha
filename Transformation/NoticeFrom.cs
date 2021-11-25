using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for operation.
    /// </summary>
    public static class NoticeFrom
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
        public static INotification<TSignal> Inverted<TSignal>(INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new NotifyToInvert<TSignal>(notification);
        }
        private sealed class NotifyToInvert<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> notification;

            internal NotifyToInvert(INotification<TSignal> notification)
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
        /// <see cref="INotification{TSignal}"/> checked first.
        /// </param>
        /// <param name="second">
        /// <see cref="INotification{TSignal}"/> checked second.
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
        public static INotification<TSignal> Multiplied<TSignal>(INotification<TSignal> first, INotification<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new NotifyToMultiply<TSignal>(first, second);
        }
        private sealed class NotifyToMultiply<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal NotifyToMultiply(INotification<TSignal> first, INotification<TSignal> second)
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
        /// <see cref="INotification{TSignal}"/> checked first.
        /// </param>
        /// <param name="second">
        /// <see cref="INotification{TSignal}"/> checked second.
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
        public static INotification<TSignal> Added<TSignal>(this INotification<TSignal> first, INotification<TSignal> second)
            where TSignal : ISignal
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return new NotifyToAdd<TSignal>(first, second);
        }
        private sealed class NotifyToAdd<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal NotifyToAdd(INotification<TSignal> first, INotification<TSignal> second)
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
