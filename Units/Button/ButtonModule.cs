using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class ButtonModule :
        IModule<IButtonHardwareHandler, IButtonSoftwareHandler>,
        IButtonHardwareHandler,
        IButtonSoftwareHandler,
        IDisposable
    {
        private IPropagation<Touch> Touch { get; }

        private IPropagation<Push> Push { get; }

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

            Touch = touch;

            Push = push;
        }

        public IButtonHardwareHandler HardwareHandler => this;

        public IButtonSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Push.Dispose();
        }

        IConsumption<Touch> IButtonHardwareHandler.Touch => Touch;

        IConsumption<Push> IButtonHardwareHandler.Push => Push;

        IProduction<Touch> IButtonSoftwareHandler.Touch => Touch;

        IProduction<Push> IButtonSoftwareHandler.Push => Push;
    }
}
