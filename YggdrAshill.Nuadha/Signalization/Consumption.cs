using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Consumption<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly Action<TSignal> onConsumed;

        #region Constructor

        public Consumption(Action<TSignal> onConsumed)
        {
            if (onConsumed == null)
            {
                throw new ArgumentNullException(nameof(onConsumed));
            }

            this.onConsumed = onConsumed;
        }

        public Consumption()
        {
            onConsumed = (_) =>
            {

            };
        }

        #endregion

        #region IConsumption

        public void Consume(TSignal signal)
        {
            onConsumed.Invoke(signal);
        }

        #endregion
    }
}
