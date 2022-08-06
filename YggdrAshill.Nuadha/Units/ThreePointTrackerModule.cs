using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IThreePointTrackerModule"/>.
    /// </summary>
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerHardware,
        IThreePointTrackerSoftware,
        IThreePointTrackerModule
    {
        /// <summary>
        /// <see cref="IThreePointTrackerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IThreePointTrackerModule"/> initialized.
        /// </returns>
        public static IThreePointTrackerModule WithoutCache()
        {
            return new ThreePointTrackerModule(HeadTrackerModule.WithoutCache(), HandControllerModule.WithoutCache(), HandControllerModule.WithoutCache());
        }

        /// <summary>
        /// <see cref="IThreePointTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IThreePointTrackerModule"/> initialized.
        /// </returns>
        public static IThreePointTrackerModule WithLatestCache()
        {
            return new ThreePointTrackerModule(HeadTrackerModule.WithLatestCache(), HandControllerModule.WithLatestCache(), HandControllerModule.WithLatestCache());
        }

        private ThreePointTrackerModule(IHeadTrackerModule head, IHandControllerModule leftHand, IHandControllerModule rightHand)
        {
            this.head = head;

            this.leftHand = leftHand;

            this.rightHand = rightHand;
        }

        private readonly IHeadTrackerModule head;

        private readonly IHandControllerModule leftHand;

        private readonly IHandControllerModule rightHand;

        /// <inheritdoc/>
        public IThreePointTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IThreePointTrackerSoftware Software => this;

        /// <inheritdoc/>
        IHeadTrackerHardware IThreePointTrackerHardware.Head => head.Hardware;

        /// <inheritdoc/>
        IHandControllerHardware IThreePointTrackerHardware.LeftHand => leftHand.Hardware;

        /// <inheritdoc/>
        IHandControllerHardware IThreePointTrackerHardware.RightHand => rightHand.Hardware;

        /// <inheritdoc/>
        IHeadTrackerSoftware IThreePointTrackerSoftware.Head => head.Software;

        /// <inheritdoc/>
        IHandControllerSoftware IThreePointTrackerSoftware.LeftHand => leftHand.Software;

        /// <inheritdoc/>
        IHandControllerSoftware IThreePointTrackerSoftware.RightHand => rightHand.Software;
    }
}
