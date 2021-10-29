using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class PropagateInputSignal :
        IPropagation<InputSignal>,
        ICancellation
    {
        private IConsumption<InputSignal> consumption;

        public ICancellation Produce(IConsumption<InputSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            this.consumption = consumption;

            return this;
        }

        public void Consume(InputSignal signal)
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
