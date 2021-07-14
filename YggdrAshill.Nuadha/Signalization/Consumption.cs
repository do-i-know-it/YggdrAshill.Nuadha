using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to consume.
    /// </typeparam>
    public sealed class Consumption<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// <see cref="Consumption{TSignal}"/> to do nothing when this has consumed <typeparamref name="TSignal"/>.
        /// </summary>
        public static Consumption<TSignal> None { get; } = new Consumption<TSignal>(_ => { });

        private readonly Action<TSignal> onConsumed;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onConsumed">
        /// <see cref="Action{T}"/> to execute when this has consumed <typeparamref name="TSignal"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onConsumed"/> is null.
        /// </exception>
        public Consumption(Action<TSignal> onConsumed)
        {
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            this.onConsumed = onConsumed;
        }

        /// <inheritdoc/>
        public void Consume(TSignal signal)
        {
            onConsumed.Invoke(signal);
        }
    }
}
