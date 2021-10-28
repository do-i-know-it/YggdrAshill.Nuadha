using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedHandController :
        IPulsatedHandControllerSoftware,
        IPulsatedHandControllerHardware,
        IProtocol<IPulsatedHandControllerSoftware, IPulsatedHandControllerHardware>
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
        public IPulsatedHandControllerSoftware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedHandControllerHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        /// <inheritdoc/>
        IPulsatedStickSoftware IPulsatedHandControllerSoftware.Thumb => thumb.Hardware;

        /// <inheritdoc/>
        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.IndexFinger => indexFinger.Hardware;

        /// <inheritdoc/>
        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.HandGrip => handGrip.Hardware;

        /// <inheritdoc/>
        IPulsatedStickHardware IPulsatedHandControllerHardware.Thumb => thumb.Software;

        /// <inheritdoc/>
        IPulsatedTriggerHardware IPulsatedHandControllerHardware.IndexFinger => indexFinger.Software;

        /// <inheritdoc/>
        IPulsatedTriggerHardware IPulsatedHandControllerHardware.HandGrip => handGrip.Software;
    }
}
