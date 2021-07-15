using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickModule :
        IStickHardwareHandler,
        IStickSoftwareHandler,
        IModule<IStickHardwareHandler, IStickSoftwareHandler>
    {
        public static StickModule WithoutCache()
        {
            return new StickModule(Propagation.WithoutCache.Create<Touch>(), Propagation.WithoutCache.Create<Tilt>());
        }

        public static StickModule WithLatestCache()
        {
            return new StickModule(Propagation.WithLatestCache.Create(Initialize.Touch), Propagation.WithLatestCache.Create(Initialize.Tilt));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Tilt> Tilt { get; }

        private StickModule(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
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
