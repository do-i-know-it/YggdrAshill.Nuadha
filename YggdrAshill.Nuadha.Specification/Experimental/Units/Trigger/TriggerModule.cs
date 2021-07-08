using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;
using System;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public sealed class TriggerModule :
        IModule<ITriggerHardware, ITriggerSoftware>,
        ITriggerHardware,
        ITriggerSoftware
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

        #region IModule

        public ITriggerHardware Hardware => this;

        public ITriggerSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        #endregion

        #region ITriggerHardware

        IProduction<Touch> ITriggerHardware.Touch => touch;

        IProduction<Pull> ITriggerHardware.Pull => pull;

        #endregion

        #region ITriggerSoftware

        IConsumption<Touch> ITriggerSoftware.Touch => touch;

        IConsumption<Pull> ITriggerSoftware.Pull => pull;

        #endregion
    }
}
