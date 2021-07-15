using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonModule :
        IButtonHardwareHandler,
        IButtonSoftwareHandler,
        IModule<IButtonHardwareHandler, IButtonSoftwareHandler>
    {
        public static ButtonModule WithoutCache()
        {
            return new ButtonModule(Propagation.WithoutCache.Create<Touch>(), Propagation.WithoutCache.Create<Push>());
        }

        public static ButtonModule WithLatestCache()
        {
            return new ButtonModule(Propagation.WithLatestCache.Create(Initialize.Touch), Propagation.WithLatestCache.Create(Initialize.Push));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Push> Push { get; }

        private ButtonModule(IPropagation<Touch> touch, IPropagation<Push> push)
        {
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
