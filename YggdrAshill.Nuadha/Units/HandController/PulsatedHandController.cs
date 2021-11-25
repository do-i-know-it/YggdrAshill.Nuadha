using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPulsatedHandControllerProtocol"/>.
    /// </summary>
    public sealed class PulsatedHandController :
        IPulsatedHandControllerHardware,
        IPulsatedHandControllerSoftware,
        IPulsatedHandControllerProtocol
    {
        /// <summary>
        /// <see cref="IPulsatedHandControllerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedHandControllerProtocol"/> initialized.
        /// </returns>
        public static IPulsatedHandControllerProtocol WithoutCache()
        {
            return new PulsatedHandController(
                PulsatedStick.WithoutCache(),
                PulsatedTrigger.WithoutCache(),
                PulsatedTrigger.WithoutCache());
        }

        /// <summary>
        /// <see cref="IPulsatedHandControllerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedHandControllerProtocol"/> initialized.
        /// </returns>
        public static IPulsatedHandControllerProtocol WithLatestCache()
        {
            return new PulsatedHandController(
                PulsatedStick.WithLatestCache(),
                PulsatedTrigger.WithLatestCache(),
                PulsatedTrigger.WithLatestCache());
        }

        private PulsatedHandController(IPulsatedStickProtocol thumb, IPulsatedTriggerProtocol indexFinger, IPulsatedTriggerProtocol handGrip)
        {
            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        /// <inheritdoc/>
        public IPulsatedStickProtocol Thumb { get; }

        /// <inheritdoc/>
        public IPulsatedTriggerProtocol IndexFinger { get; }

        /// <inheritdoc/>
        public IPulsatedTriggerProtocol HandGrip { get; }

        /// <inheritdoc/>
        public IPulsatedHandControllerHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedHandControllerSoftware Software => this;

        /// <inheritdoc/>
        IPulsatedStickHardware IPulsatedHandControllerHardware.Thumb => Thumb.Hardware;

        /// <inheritdoc/>
        IPulsatedTriggerHardware IPulsatedHandControllerHardware.IndexFinger => IndexFinger.Hardware;

        /// <inheritdoc/>
        IPulsatedTriggerHardware IPulsatedHandControllerHardware.HandGrip => HandGrip.Hardware;

        /// <inheritdoc/>
        IPulsatedStickSoftware IPulsatedHandControllerSoftware.Thumb => Thumb.Software;

        /// <inheritdoc/>
        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.IndexFinger => IndexFinger.Software;

        /// <inheritdoc/>
        IPulsatedTriggerSoftware IPulsatedHandControllerSoftware.HandGrip => HandGrip.Software;
    }
}
