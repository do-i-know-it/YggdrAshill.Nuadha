using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class ButtonModule :
        IButtonHardwareHandler,
        IButtonSoftwareHandler,
        IModule<IButtonHardwareHandler, IButtonSoftwareHandler>
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Push> push;

        internal ButtonModule(IButtonModule module)
        {
            touch = module.Touch;

            push = module.Push;
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
