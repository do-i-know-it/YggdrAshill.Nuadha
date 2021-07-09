using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedButtonModule :
        IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler>,
        IPulsatedButtonSoftwareHandler,
        IPulsatedButtonHardwareHandler
    {
        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        public PulsatedButtonModule(IPropagation<Pulse> touch, IPropagation<Pulse> push)
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