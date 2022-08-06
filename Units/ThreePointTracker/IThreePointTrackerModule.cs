using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IThreePointTrackerHardware"/> and <see cref="IThreePointTrackerSoftware"/>.
    /// </summary>
    public interface IThreePointTrackerModule :
        IModule<IThreePointTrackerHardware, IThreePointTrackerSoftware>
    {
        /// <summary>
        /// <see cref="IHeadTrackerModule"/> for head.
        /// </summary>
        IHeadTrackerModule Head { get; }

        /// <summary>
        /// <see cref="IHandControllerModule"/> for left hand.
        /// </summary>
        IHandControllerModule LeftHand { get; }

        /// <summary>
        /// <see cref="IHandControllerModule"/> for right hand.
        /// </summary>
        IHandControllerModule RightHand { get; }
    }
}
