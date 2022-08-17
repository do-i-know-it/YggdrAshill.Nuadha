using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="ISoftware"/> for three point tracker.
    /// </summary>
    public interface IThreePointTrackerSoftware :
        ISoftware
    {
        /// <summary>
        /// <see cref="IHeadTrackerSoftware"/> for head.
        /// </summary>
        IHeadTrackerSoftware Head { get; }

        /// <summary>
        /// <see cref="IHandControllerSoftware"/> for left hand.
        /// </summary>
        IHandControllerSoftware LeftHand { get; }

        /// <summary>
        /// <see cref="IHandControllerSoftware"/> for right hand.
        /// </summary>
        IHandControllerSoftware RightHand { get; }
    }
}
