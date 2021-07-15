using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedHandControllerModule :
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler,
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PulsatedHandControllerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedHandControllerModule"/> without cache.
        /// </returns>
        public static PulsatedHandControllerModule WithoutCache()
        {
            return new PulsatedHandControllerModule(
                PulsatedStickModule.WithoutCache(),
                PulsatedTriggerModule.WithoutCache(),
                PulsatedTriggerModule.WithoutCache());
        }

        /// <summary>
        /// <see cref="PulsatedHandControllerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedHandControllerModule"/> with latest cache.
        /// </returns>
        public static PulsatedHandControllerModule WithLatestCache()
        {
            return new PulsatedHandControllerModule(
                PulsatedStickModule.WithLatestCache(),
                PulsatedTriggerModule.WithLatestCache(),
                PulsatedTriggerModule.WithLatestCache());
        }

        private readonly PulsatedStickModule thumb;

        private readonly PulsatedTriggerModule indexFinger;

        private readonly PulsatedTriggerModule handGrip;

        private PulsatedHandControllerModule(PulsatedStickModule thumb, PulsatedTriggerModule indexFinger, PulsatedTriggerModule handGrip)
        {
            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        /// <inheritdoc/>
        public IPulsatedHandControllerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPulsatedHandControllerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        /// <inheritdoc/>
        IPulsatedStickHardwareHandler IPulsatedHandControllerHardwareHandler.Thumb => thumb.HardwareHandler;

        /// <inheritdoc/>
        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.IndexFinger => indexFinger.HardwareHandler;

        /// <inheritdoc/>
        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.HandGrip => handGrip.HardwareHandler;

        /// <inheritdoc/>
        IPulsatedStickSoftwareHandler IPulsatedHandControllerSoftwareHandler.Thumb => thumb.SoftwareHandler;

        /// <inheritdoc/>
        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.IndexFinger => indexFinger.SoftwareHandler;

        /// <inheritdoc/>
        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.HandGrip => handGrip.SoftwareHandler;
    }
}
