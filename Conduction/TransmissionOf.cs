using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    public static class TransmissionOf
    {
        public static ITransmission<TSignal> Signal<TSignal>(IGeneration<TSignal> generation, IPropagation<TSignal> propagation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }

            return new Transmit<TSignal>(generation, propagation);
        }
        private sealed class Transmit<TSignal> :
            ITransmission<TSignal>
            where TSignal : ISignal
        {
            private readonly IGeneration<TSignal> generation;

            private readonly IPropagation<TSignal> propagation;

            internal Transmit(IGeneration<TSignal> generation, IPropagation<TSignal> propagation)
            {
                this.generation = generation;

                this.propagation = propagation;
            }

            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return propagation.Produce(consumption);
            }

            public void Emit()
            {
                var signal = generation.Generate();

                propagation.Consume(signal);
            }

            public void Dispose()
            {
                propagation.Dispose();
            }
        }
    }
}
