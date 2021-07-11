using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickModule :
        IModule<IStickHardwareHandler, IStickSoftwareHandler>,
        IStickHardwareHandler,
        IStickSoftwareHandler,
        IDisposable
    {
        private IPropagation<Touch> Touch { get; }

        private IPropagation<Tilt> Tilt { get; }

        public StickModule(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (tilt == null)
            {
                throw new ArgumentNullException(nameof(tilt));
            }

            Touch = touch;

            Tilt = tilt;
        }

        public IStickHardwareHandler HardwareHandler => this;

        public IStickSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Tilt.Dispose();
        }

        IConsumption<Touch> IStickHardwareHandler.Touch => Touch;

        IConsumption<Tilt> IStickHardwareHandler.Tilt => Tilt;

        IProduction<Touch> IStickSoftwareHandler.Touch => Touch;

        IProduction<Tilt> IStickSoftwareHandler.Tilt => Tilt;
    }
}
