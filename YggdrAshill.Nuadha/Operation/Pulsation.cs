using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Pulsation<TSignal> :
        IPulsation<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<TSignal, TSignal, bool> onPulsated;

        public Pulsation(Func<TSignal, TSignal, bool> onPulsated)
        {
            if (onPulsated == null)
            {
                throw new ArgumentNullException(nameof(onPulsated));
            }

            this.onPulsated = onPulsated;
        }

        public bool Pulsate(TSignal previous, TSignal current)
        {
            return onPulsated.Invoke(previous, current);
        }
    }
}
