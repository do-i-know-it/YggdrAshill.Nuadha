using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public static class Transmit
    {
        internal static ITransmission<TSignal> Signal<TSignal>(IGeneration<TSignal> generation, IPropagation<TSignal> propagation)
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

            return new Transmission<TSignal>(generation, propagation);
        }
        private sealed class Transmission<TSignal> :
            ITransmission<TSignal>
            where TSignal : ISignal
        {
            private readonly IGeneration<TSignal> generation;

            private readonly IPropagation<TSignal> propagation;

            internal Transmission(IGeneration<TSignal> generation, IPropagation<TSignal> propagation)
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

        public static ITransmission<TSignal> Signal<TSignal>(IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return Signal(generation, Propagate.WithoutCache<TSignal>());
        }

        public static ITransmission<TSignal> Signal<TSignal>(Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return Signal(Generate.Signal(generation));
        }
    }
}
