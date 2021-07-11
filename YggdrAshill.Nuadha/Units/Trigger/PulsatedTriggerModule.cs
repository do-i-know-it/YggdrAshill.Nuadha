using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTriggerModule :
        IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler>,
        IPulsatedTriggerHardwareHandler,
        IPulsatedTriggerSoftwareHandler,
        IDisposable
    {
        private IPropagation<Pulse> Touch { get; }

        private IPropagation<Pulse> Pull { get; }

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

            Touch = touch;

            Pull = pull;
        }

        public IPulsatedTriggerHardwareHandler HardwareHandler => this;

        public IPulsatedTriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Pull.Dispose();
        }

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Touch => Touch;

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Pull => Pull;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Touch => Touch;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Pull => Pull;
    }
}
