using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class ButtonModule :
        IModule<IButtonHardware, IButtonSoftware>,
        IButtonHardware,
        IButtonSoftware
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Push> push;

        public ButtonModule(IPropagation<Touch> touch, IPropagation<Push> push)
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

        public IButtonHardware Hardware => this;

        public IButtonSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        #endregion

        #region IButtonHardware

        IProduction<Touch> IButtonHardware.Touch => touch;

        IProduction<Push> IButtonHardware.Push => push;

        #endregion

        #region IButtonSoftware

        IConsumption<Touch> IButtonSoftware.Touch => touch;

        IConsumption<Push> IButtonSoftware.Push => push;

        #endregion
    }
}
