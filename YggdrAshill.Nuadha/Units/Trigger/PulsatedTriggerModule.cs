using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTriggerModule :
        IPulsatedTriggerHardwareHandler,
        IPulsatedTriggerSoftwareHandler,
        IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler>
    {
        public static PulsatedTriggerModule WithoutCache()
        {
            return new PulsatedTriggerModule(Propagation.WithoutCache.Create<Pulse>(), Propagation.WithoutCache.Create<Pulse>());
        }

        public static PulsatedTriggerModule WithLatestCache()
        {
            return new PulsatedTriggerModule(Propagation.WithLatestCache.Create(Initialize.Pulse), Propagation.WithLatestCache.Create(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        private PulsatedTriggerModule(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
        {
            this.touch = touch;

            this.pull = pull;
        }

        public IPulsatedTriggerHardwareHandler HardwareHandler => this;

        public IPulsatedTriggerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Touch => touch;

        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Pull => pull;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Touch => touch;

        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Pull => pull;
    }
}
