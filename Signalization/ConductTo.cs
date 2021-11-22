using System;

namespace YggdrAshill.Nuadha.Signalization
{
    public static class ConductTo
    {
        public static IEmission Consume<TSignal>(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Emission<TSignal>(generation, consumption);
        }
        private sealed class Emission<TSignal> :
            IEmission
            where TSignal : ISignal
        {
            private readonly IGeneration<TSignal> generation;

            private readonly IConsumption<TSignal> consumption;

            internal Emission(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
            {
                this.generation = generation;

                this.consumption = consumption;
            }

            public void Emit()
            {
                var signal = generation.Generate();

                consumption.Consume(signal);
            }
        }
    }
}
