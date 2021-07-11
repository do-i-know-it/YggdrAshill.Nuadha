using System;

namespace YggdrAshill.Nuadha.Signalization
{
    internal sealed class Consumption<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly Action<TSignal> onConsumed;

        internal Consumption(Action<TSignal> onConsumed)
        {
            this.onConsumed = onConsumed;
        }

        /// <inheritdoc/>
        public void Consume(TSignal signal)
        {
            onConsumed.Invoke(signal);
        }
    }
}
