using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class TriggerModule :
        ITriggerHardwareHandler,
        ITriggerSoftwareHandler,
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>
    {
        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Pull> Pull { get; }

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
