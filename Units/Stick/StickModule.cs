using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class StickModule :
        IStickHardwareHandler,
        IStickSoftwareHandler,
        IModule<IStickHardwareHandler, IStickSoftwareHandler>
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Tilt> tilt;

        public StickModule(IStickModule module)
        {
            touch = module.Touch;

            tilt = module.Tilt;
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
