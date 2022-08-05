using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class ConsumePulse :
        IConsumption<Pulse>
    {
        internal bool Consumed { get; private set; }

        public void Consume(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            Consumed = true;
        }
    }
}
