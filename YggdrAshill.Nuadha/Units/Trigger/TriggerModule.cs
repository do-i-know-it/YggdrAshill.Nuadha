using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerModule :
        ITriggerHardwareHandler,
        ITriggerSoftwareHandler,
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>
    {
        public static TriggerModule WithoutCache()
        {
            return new TriggerModule(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Pull>());
        }

        public static TriggerModule WithLatestCache()
        {
            return new TriggerModule(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Pull));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Pull> Pull { get; }

        private TriggerModule(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        public ITriggerHardwareHandler HardwareHandler => this;

        public ITriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Pull.Dispose();
        }

        IConsumption<Touch> ITriggerHardwareHandler.Touch => Touch;

        IConsumption<Pull> ITriggerHardwareHandler.Pull => Pull;

        IProduction<Touch> ITriggerSoftwareHandler.Touch => Touch;

        IProduction<Pull> ITriggerSoftwareHandler.Pull => Pull;
    }
}
