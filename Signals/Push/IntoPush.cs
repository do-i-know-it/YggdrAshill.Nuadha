using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public static class IntoPush
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Push"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="notification">
        /// <see cref="INotification{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Push> From<TSignal>(INotification<TSignal> notification)
            where TSignal : ISignal
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new PushFrom<TSignal>(notification);
        }
        private sealed class PushFrom<TSignal> :
            ITranslation<TSignal, Push>
            where TSignal : ISignal
        {
            private readonly INotification<TSignal> notification;

            internal PushFrom(INotification<TSignal> notification)
            {
                this.notification = notification;
            }

            public Push Translate(TSignal signal)
            {
                return (Push)notification.Notify(signal);
            }
        }
    }
}
