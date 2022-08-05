using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class IntoPull
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Pull"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Pull> From<TSignal>(INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new PullFrom<TSignal>(notification);
        }
        private sealed class PullFrom<TSignal> :
            ITranslation<TSignal, Pull>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> notification;

            internal PullFrom(INotification<TSignal> notification)
            {
                this.notification = notification;
            }

            public Pull Translate(TSignal signal)
            {
                return (Pull)notification.Notify(signal);
            }
        }
    }
}
