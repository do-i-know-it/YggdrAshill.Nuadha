using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/>.
    /// </summary>
    public static class NoticeFrom
    {
        /// <summary>
        /// Inverts <see cref="INotification{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
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

            return new InvertedNotified<TSignal>(notification);
        }
        private sealed class InvertedNotified<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> condition;

            internal InvertedNotified(INotification<TSignal> condition)
            {
                this.condition = condition;
            }

            public bool Notify(TSignal signal)
            {
                return !condition.Notify(signal);
            }
        }

        /// <summary>
        /// Multiplies two <see cref="INotification{TSignal}"/>s.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
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

            return new MultipliedNotified<TSignal>(first, second);
        }
        private sealed class MultipliedNotified<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal MultipliedNotified(INotification<TSignal> first, INotification<TSignal> second)
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
        /// Type of <see cref="ISignal"/> to detect.
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

            return new AddedNotified<TSignal>(first, second);
        }
        private sealed class AddedNotified<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> first;

            private readonly INotification<TSignal> second;

            internal AddedNotified(INotification<TSignal> first, INotification<TSignal> second)
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
