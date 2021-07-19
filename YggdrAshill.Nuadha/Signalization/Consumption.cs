using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    public static class Consumption
    {
        /// <summary>
        /// Executes <see cref="Action{T}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to consume.
        /// </typeparam>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> Of<TSignal>(Action<TSignal> consumption)
            where TSignal : ISignal
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Created<TSignal>(consumption);
        }
        private sealed class Created<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly Action<TSignal> onConsumed;

            internal Created(Action<TSignal> onConsumed)
            {
                this.onConsumed = onConsumed;
            }

            /// <inheritdoc/>
            public void Consume(TSignal signal)
            {
                onConsumed.Invoke(signal);
            }
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to consume.
        /// </typeparam>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> created.
        /// </returns>
        public static IConsumption<TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Of<TSignal>(_ => { });
        }
    }
}
