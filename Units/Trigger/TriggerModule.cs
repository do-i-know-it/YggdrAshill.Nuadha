using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class TriggerModule :
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>,
        ITriggerHardwareHandler,
        ITriggerSoftwareHandler,
        IDisposable
    {
        private IPropagation<Touch> Touch { get; }

        private IPropagation<Pull> Pull { get; }

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

            Touch = touch;

            Pull = pull;
        }

        public ITriggerHardwareHandler HardwareHandler => this;

        public ITriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Pull.Dispose();
        }

        IConsumption<Touch> ITriggerHardwareHandler.Touch => Touch;

        IConsumption<Pull> ITriggerHardwareHandler.Pull => Pull;

        IProduction<Touch> ITriggerSoftwareHandler.Touch => Touch;

        IProduction<Pull> ITriggerSoftwareHandler.Pull => Pull;
    }
}
