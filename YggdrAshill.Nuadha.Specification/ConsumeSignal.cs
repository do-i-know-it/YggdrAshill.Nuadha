using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class ConsumeSignal :
        IConsumption<Signal>
    {
        internal Signal Consumed { get; private set; }

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            Consumed = signal;
        }
    }
}
