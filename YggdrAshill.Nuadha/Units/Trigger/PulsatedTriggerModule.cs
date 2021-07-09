using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTriggerModule :
        IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler>,
        IPulsatedTriggerSoftwareHandler,
        IPulsatedTriggerHardwareHandler
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        public PulsatedTriggerModule(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
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
