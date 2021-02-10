using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class Emission<TSignal> :
        IEmission
        where TSignal : ISignal
    {
        private readonly IGeneration<TSignal> generation;

        private readonly IConsumption<TSignal> consumption;

        public Emission(IGeneration<TSignal> generation, IConsumption<TSignal> consumption)
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
