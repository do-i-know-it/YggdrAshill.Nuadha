using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class ConsumeOutputSignal :
        IConsumption<OutputSignal>
    {
        internal OutputSignal Consumed { get; private set; }

        public void Consume(OutputSignal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            Consumed = signal;
        }
    }
}
