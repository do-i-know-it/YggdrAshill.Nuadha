using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedButtonModule :
        IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler>,
        IPulsatedButtonHardwareHandler,
        IPulsatedButtonSoftwareHandler,
        IDisposable
    {
        private IPropagation<Pulse> Touch { get; }

        private IPropagation<Pulse> Push { get; }

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

            Touch = touch;

            Push = push;
        }

        public IPulsatedButtonHardwareHandler HardwareHandler => this;

        public IPulsatedButtonSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Push.Dispose();
        }

        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Touch => Touch;

        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Push => Push;

        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Touch => Touch;

        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Push => Push;
    }
}
