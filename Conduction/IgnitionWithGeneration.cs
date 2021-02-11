using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class IgnitionWithGeneration<TSignal> :
        IIgnition
        where TSignal : ISignal
    {
        private readonly IGeneration<TSignal> generation;

        private readonly IConsumption<TSignal> consumption;

        public IgnitionWithGeneration(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
        {
            this.generation = generation;

            this.consumption = consumption;
        }

        public IEmission Ignite()
        {
            return new EmissionWithGeneration<TSignal>(generation, consumption);
        }
    }
}
