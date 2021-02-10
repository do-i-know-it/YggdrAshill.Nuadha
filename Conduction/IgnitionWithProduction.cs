using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    internal sealed class IgnitionWithProduction<TSignal> :
        IIgnition
        where TSignal : ISignal
    {
        private readonly IProduction<TSignal> production;

        private readonly IConsumption<TSignal> consumption;

        public IgnitionWithProduction(IProduction<TSignal> production, IConsumption<TSignal> consumption)
        {
            this.production = production;

            this.consumption = consumption;
        }

        public IEmission Ignite()
        {
            return production.Produce(consumption);
        }
    }
}
