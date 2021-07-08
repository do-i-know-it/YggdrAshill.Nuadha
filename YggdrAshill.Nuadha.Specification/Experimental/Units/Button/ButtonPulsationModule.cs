using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public sealed class ButtonPulsationModule :
        IModule<IButtonPulsationHardware, IButtonPulsationSoftware>,
        IButtonPulsationHardware,
        IButtonPulsationSoftware
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        public ButtonPulsationModule(IPropagation<Pulse> touch, IPropagation<Pulse> push)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (push == null)
            {
                throw new ArgumentNullException(nameof(push));
            }

            this.touch = touch;

            this.push = push;
        }

        #region IModule

        public IButtonPulsationHardware Hardware => this;

        public IButtonPulsationSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        #endregion

        #region IButtonPulsationHardware

        IProduction<Pulse> IButtonPulsationHardware.Touch => touch;

        IProduction<Pulse> IButtonPulsationHardware.Push => push;

        #endregion

        #region IButtonPulsationSoftware

        IConsumption<Pulse> IButtonPulsationSoftware.Touch => touch;

        IConsumption<Pulse> IButtonPulsationSoftware.Push => push;

        #endregion
    }
}
