using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class StickModule :
        IStickHardwareHandler,
        IStickSoftwareHandler,
        IModule<IStickHardwareHandler, IStickSoftwareHandler>
    {
        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Tilt> Tilt { get; }

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
