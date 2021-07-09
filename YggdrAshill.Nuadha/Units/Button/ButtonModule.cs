using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IModule<IButtonHardwareHandler, IButtonSoftwareHandler>,
        IButtonHardwareHandler,
        IButtonSoftwareHandler
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

        public IButtonHardwareHandler HardwareHandler => this;

        public IButtonSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        IConsumption<Touch> IButtonHardwareHandler.Touch => touch;

        IConsumption<Push> IButtonHardwareHandler.Push => push;

        IProduction<Touch> IButtonSoftwareHandler.Touch => touch;

        IProduction<Push> IButtonSoftwareHandler.Push => push;
    }
}
