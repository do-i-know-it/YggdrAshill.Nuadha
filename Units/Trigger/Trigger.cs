using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class Trigger :
        ITrigger
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Pull> Pull { get; }

        internal Trigger(ITriggerModule module, ITriggerConfiguration configuration)
        {
            Touch = module.Touch.Transmit(configuration.Touch);

            Pull = module.Pull.Transmit(configuration.Pull);
        }
    }
}
