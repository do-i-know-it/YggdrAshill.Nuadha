using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class StickModule :
        IModule<IStickHardwareHandler, IStickSoftwareHandler>,
        IStickSoftwareHandler,
        IStickHardwareHandler
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Tilt> tilt;

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

            this.touch = touch;

            this.tilt = tilt;
        }

        public IStickHardwareHandler HardwareHandler => this;

        public IStickSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        IConsumption<Touch> IStickHardwareHandler.Touch => touch;

        IConsumption<Tilt> IStickHardwareHandler.Tilt => tilt;

        IProduction<Touch> IStickSoftwareHandler.Touch => touch;

        IProduction<Tilt> IStickSoftwareHandler.Tilt => tilt;
    }
}
