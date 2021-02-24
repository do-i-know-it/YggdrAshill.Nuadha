using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class ProductionWithGeneration<TSignal> :
        IProduction<TSignal>
        where TSignal : ISignal
    {
        private readonly IGeneration<TSignal> generation;

        public ProductionWithGeneration(IGeneration<TSignal> generation)
        {
            this.generation = generation;
        }

        public IEmission Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new EmissionWithGeneration<TSignal>(generation, consumption);
        }
    }
}
