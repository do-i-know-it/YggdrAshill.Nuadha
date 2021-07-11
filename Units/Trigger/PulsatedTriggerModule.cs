using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PulsatedTriggerModule :
        IPulsatedTriggerHardwareHandler,
        IPulsatedTriggerSoftwareHandler,
        IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler>
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        internal PulsatedTriggerModule(IPulsatedTriggerModule module)
        {
            touch = module.Touch;

            pull = module.Pull;
        }

        public IPulsatedTriggerHardwareHandler HardwareHandler => this;

        public IPulsatedTriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Touch => touch;

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Pull => pull;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Touch => touch;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Pull => pull;
    }
}
