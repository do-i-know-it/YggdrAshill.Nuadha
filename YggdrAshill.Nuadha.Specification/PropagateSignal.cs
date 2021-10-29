using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class PropagateSignal :
        IPropagation<Signal>,
        ICancellation
    {
        private IConsumption<Signal> consumption;

        public ICancellation Produce(IConsumption<Signal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.consumption = consumption;

            return this;
        }

        public void Consume(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            consumption.Consume(signal);
        }

        public void Cancel()
        {
            consumption = null;
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}
