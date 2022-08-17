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
        public static IThreePointTrackerModule WithoutCache()
        {
            return new ThreePointTrackerModule(HeadTrackerModule.WithList(), HandControllerModule.WithList(), HandControllerModule.WithList());
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
        public void Dispose()
        {
            head.Dispose();

            leftHand.Dispose();

            rightHand.Dispose();
        }

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
