using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHardware"/> for three point tracker.
    /// </summary>
    public interface IThreePointTrackerHardware :
        IHardware
    {
        /// <summary>
        /// <see cref="IHeadTrackerHardware"/> for head.
        /// </summary>
        IHeadTrackerHardware Head { get; }

        /// <summary>
        /// <see cref="IHandControllerHardware"/> for left hand.
        /// </summary>
        IHandControllerHardware LeftHand { get; }

        /// <summary>
        /// <see cref="IHandControllerHardware"/> for right hand.
        /// </summary>
        IHandControllerHardware RightHand { get; }
    }
}
