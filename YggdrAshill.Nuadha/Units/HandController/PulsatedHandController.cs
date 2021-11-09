using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedHandControllerHardware"/> and <see cref="IPulsatedHandControllerSoftware"/>.
    /// </summary>
    public sealed class PulsatedHandController :
        IPulsatedHandControllerHardware,
        IPulsatedHandControllerSoftware,
        IProtocol<IPulsatedHandControllerHardware, IPulsatedHandControllerSoftware>
    {
        /// <summary>
        /// <see cref="PulsatedHandController"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedHandController"/> without cache.
        /// </returns>
        public static PulsatedHandController WithoutCache()
        {
            return new PulsatedHandController(
                PulsatedStick.WithoutCache(),
                PulsatedTrigger.WithoutCache(),
                PulsatedTrigger.WithoutCache());
        }

        /// <summary>
        /// <see cref="PulsatedHandController"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedHandController"/> with latest cache.
        /// </returns>
        public static PulsatedHandController WithLatestCache()
        {
            return new PulsatedHandController(
                PulsatedStick.WithLatestCache(),
                PulsatedTrigger.WithLatestCache(),
                PulsatedTrigger.WithLatestCache());
        }

        private readonly PulsatedStick thumb;

        private readonly PulsatedTrigger indexFinger;

        private readonly PulsatedTrigger handGrip;

        private PulsatedHandController(PulsatedStick thumb, PulsatedTrigger indexFinger, PulsatedTrigger handGrip)
        {
            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        /// <inheritdoc/>
        public IPulsatedHandControllerHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedHandControllerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        IPulsatedStickHardware IPulsatedHandControllerHardware.Thumb => thumb.Hardware;

        IPulsatedTriggerHardware IPulsatedHandControllerHardware.IndexFinger => indexFinger.Hardware;

        IPulsatedTriggerHardware IPulsatedHandControllerHardware.HandGrip => handGrip.Hardware;

        IPulsatedStickSoftware IPulsatedHandControllerSoftware.Thumb => thumb.Software;

        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.IndexFinger => indexFinger.Software;

        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.HandGrip => handGrip.Software;
    }
}
