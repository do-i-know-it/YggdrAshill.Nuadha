using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedButtonModule :
        IPulsatedButtonHardwareHandler,
        IPulsatedButtonSoftwareHandler,
        IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler>
    {
        public static PulsatedButtonModule WithoutCache()
        {
            return new PulsatedButtonModule(Propagation.WithoutCache.Of<Pulse>(), Propagation.WithoutCache.Of<Pulse>());
        }

        public static PulsatedButtonModule WithLatestCache()
        {
            return new PulsatedButtonModule(Propagation.WithLatestCache.Of(Initialize.Pulse), Propagation.WithLatestCache.Of(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        private PulsatedButtonModule(IPropagation<Pulse> touch, IPropagation<Pulse> push)
        {
            this.touch = touch;

            this.push = push;
        }

        public IPulsatedButtonHardwareHandler HardwareHandler => this;

        public IPulsatedButtonSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Touch => touch;

        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Push => push;

        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Touch => touch;

        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Push => push;
    }
}
