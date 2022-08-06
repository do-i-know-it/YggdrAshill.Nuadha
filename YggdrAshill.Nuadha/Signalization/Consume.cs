using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to consume.
    /// </typeparam>
    public static class Consume<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Receives <typeparamref name="TSignal"/> to consume.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TSignal> With(Action<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new ConsumeWithFunction(consumption);
        }
        private sealed class ConsumeWithFunction :
            IConsumption<TSignal>
        {
            private readonly Action<TSignal> onConsumed;

            internal ConsumeWithFunction(Action<TSignal> onConsumed)
            {
                this.onConsumed = onConsumed;
            }

            public void Consume(TSignal signal)
            {
                onConsumed.Invoke(signal);
            }
        }
    }
}
