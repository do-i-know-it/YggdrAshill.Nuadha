using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public sealed class TriggerPulsationModule :
        IModule<ITriggerPulsationHardware, ITriggerPulsationSoftware>,
        ITriggerPulsationHardware,
        ITriggerPulsationSoftware
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        public TriggerPulsationModule(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
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

        #region IModule

        public ITriggerPulsationHardware Hardware => this;

        public ITriggerPulsationSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        #endregion

        #region ITriggerPulsationHardware

        IProduction<Pulse> ITriggerPulsationHardware.Touch => touch;

        IProduction<Pulse> ITriggerPulsationHardware.Pull => pull;

        #endregion

        #region ITriggerPulsationSoftware

        IConsumption<Pulse> ITriggerPulsationSoftware.Touch => touch;

        IConsumption<Pulse> ITriggerPulsationSoftware.Pull => pull;

        #endregion
    }
}
