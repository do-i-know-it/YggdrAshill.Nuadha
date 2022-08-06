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
            Head = head;

            LeftHand = leftHand;

            RightHand = rightHand;
        }

        /// <inheritdoc/>
        public IHeadTrackerModule Head { get; }

        /// <inheritdoc/>
        public IHandControllerModule LeftHand { get; }

        /// <inheritdoc/>
        public IHandControllerModule RightHand { get; }

        /// <inheritdoc/>
        public IThreePointTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IThreePointTrackerSoftware Software => this;

        /// <inheritdoc/>
        IHeadTrackerHardware IThreePointTrackerHardware.Head => Head.Hardware;

        /// <inheritdoc/>
        IHandControllerHardware IThreePointTrackerHardware.LeftHand => LeftHand.Hardware;

        /// <inheritdoc/>
        IHandControllerHardware IThreePointTrackerHardware.RightHand => RightHand.Hardware;

        /// <inheritdoc/>
        IHeadTrackerSoftware IThreePointTrackerSoftware.Head => Head.Software;

        /// <inheritdoc/>
        IHandControllerSoftware IThreePointTrackerSoftware.LeftHand => LeftHand.Software;

        /// <inheritdoc/>
        IHandControllerSoftware IThreePointTrackerSoftware.RightHand => RightHand.Software;
    }
}
