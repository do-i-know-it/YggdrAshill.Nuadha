using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class Trigger :
        ITrigger
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Pull> Pull { get; }

        internal Trigger(ITriggerConfiguration configuration)
        {
            Touch = new PropagationWithoutCache<Touch>().Transmit(configuration.Touch);

            Pull = new PropagationWithoutCache<Pull>().Transmit(configuration.Pull);
        }
    }
}
