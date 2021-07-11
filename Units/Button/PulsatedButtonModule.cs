using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PulsatedButtonModule :
        IPulsatedButtonHardwareHandler,
        IPulsatedButtonSoftwareHandler,
        IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler>
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        internal PulsatedButtonModule(IPulsatedButtonModule module)
        {
            touch = module.Touch;

            push = module.Push;
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
