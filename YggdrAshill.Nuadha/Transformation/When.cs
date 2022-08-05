using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for <see cref="INotification{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notify.
    /// </typeparam>
    public static class When<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Notifies <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="notification">
        /// <see cref="Func{T, TResult}"/> to notify <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> to notify <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notification"/> is null.
        /// </exception>
        public static INotification<TSignal> Is(Func<TSignal, bool> notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new NotifyWithFunction(notification);
        }
        private sealed class NotifyWithFunction :
            INotification<TSignal>
        {
            private readonly Func<TSignal, bool> onNotified;

            internal NotifyWithFunction(Func<TSignal, bool> onNotified)
            {
                this.onNotified = onNotified;
            }

            public bool Notify(TSignal signal)
            {
                return onNotified.Invoke(signal);
            }
        }

        /// <summary>
        /// Always notifies <typeparamref name="TSignal"/>.
        /// </summary>
        public static INotification<TSignal> All { get; } = Is(_ => true);

        /// <summary>
        /// Never notifies <typeparamref name="TSignal"/>.
        /// </summary>
        public static INotification<TSignal> None { get; } = Is(_ => false);
    }
}
