using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    public static class Consume
    {
        /// <summary>
        /// Converts <see cref="Action{T}"/> for <typeparamref name="TSignal"/> into <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to consume.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> for <typeparamref name="TSignal"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> converted from <see cref="Action{T}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Signal<TSignal>(Action<TSignal> consumption)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Consumption<TSignal>(consumption);
        }
        private sealed class Consumption<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly Action<TSignal> onConsumed;

            internal Consumption(Action<TSignal> onConsumed)
            {
                this.onConsumed = onConsumed;
            }

            public void Consume(TSignal signal)
            {
                onConsumed.Invoke(signal);
            }
        }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to do nothing.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to consume.
        /// </typeparam>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to do nothing.
        /// </returns>
        public static IConsumption<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal>(_ => { });
        }
    }
}
