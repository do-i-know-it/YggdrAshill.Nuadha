using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class EmissionWithGeneration<TSignal> :
        IEmission
        where TSignal : ISignal
    {
        private readonly IGeneration<TSignal> generation;

        private readonly IConsumption<TSignal> consumption;

        public EmissionWithGeneration(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
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
