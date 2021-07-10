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
        private readonly Action<TSignal> onConsumed;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onConsumed">
        /// <see cref="Action{TSignal}"/> to execute when this has consumed.
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

        /// <summary>
        /// Constructs an instance to do nothing when this has consumed.
        /// </summary>
        public Consumption()
        {
            onConsumed = (_) =>
            {

            };
        }

        #endregion

        #region IConsumption

        /// <inheritdoc/>
        public void Consume(TSignal signal)
        {
            onConsumed.Invoke(signal);
        }

        #endregion
    }
}
