using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class Production<TSignal> :
        IProduction<TSignal>
        where TSignal : ISignal
    {
        private readonly IGeneration<TSignal> generation;

        public Production(IGeneration<TSignal> generation)
        {
            this.generation = generation;
        }

        public IEmission Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Emission<TSignal>(generation, consumption);
        }
    }
}
