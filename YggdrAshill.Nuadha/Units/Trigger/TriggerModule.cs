using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>,
        ITriggerSoftwareHandler,
        ITriggerHardwareHandler
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Pull> pull;

        public TriggerModule(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (pull == null)
            {
                throw new ArgumentNullException(nameof(pull));
            }

            this.touch = touch;

            this.pull = pull;
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
