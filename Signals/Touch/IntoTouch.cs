using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Touch"/>.
    /// </summary>
    public static class IntoTouch
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Touch> From<TSignal>(INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new TouchFrom<TSignal>(notification);
        }
        private sealed class TouchFrom<TSignal> :
            ITranslation<TSignal, Touch>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> notification;

            internal TouchFrom(INotification<TSignal> notification)
            {
                this.notification = notification;
            }

            public Touch Translate(TSignal signal)
            {
                return (Touch)notification.Notify(signal);
            }
        }
    }
}
