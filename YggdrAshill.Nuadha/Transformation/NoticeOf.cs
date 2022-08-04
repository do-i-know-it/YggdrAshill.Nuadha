using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for <see cref="INotification{TSignal}"/>.
    /// </summary>
    public static class NoticeOf
    {
        /// <summary>
        /// Executes <see cref="Func{T, TResult}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <param name="condition">
        /// <see cref="Func{T, TResult}"/> to detect <see cref="Notice"/> of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static INotification<TSignal> Signal<TSignal>(Func<TSignal, bool> condition)
            where TSignal : ISignal
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new Condition<TSignal>(condition);
        }
        private sealed class Condition<TSignal> :
            INotification<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, bool> condition;

            internal Condition(Func<TSignal, bool> condition)
            {
                this.condition = condition;
            }

            public bool Notify(TSignal signal)
            {
                return condition.Invoke(signal);
            }
        }

        /// <summary>
        /// Notifies all of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> created.
        /// </returns>
        public static INotification<TSignal> All<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => true);
        }

        /// <summary>
        /// Notifies none of <typeparamref name="TSignal"/> even if <typeparamref name="TSignal"/> is <see cref="null"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to detect.
        /// </typeparam>
        /// <returns>
        /// <see cref="INotification{TSignal}"/> created.
        /// </returns>
        public static INotification<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => false);
        }
    }
}
