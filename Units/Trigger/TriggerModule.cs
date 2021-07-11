using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class TriggerModule :
        ITriggerHardwareHandler,
        ITriggerSoftwareHandler,
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Pull> pull;

        internal TriggerModule(ITriggerModule module)
        {
            touch = module.Touch;

            pull = module.Pull;
        }

        public ITriggerHardwareHandler HardwareHandler => this;

        public ITriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        IConsumption<Touch> ITriggerHardwareHandler.Touch => touch;

        IConsumption<Pull> ITriggerHardwareHandler.Pull => pull;

        IProduction<Touch> ITriggerSoftwareHandler.Touch => touch;

        IProduction<Pull> ITriggerSoftwareHandler.Pull => pull;
    }
}
