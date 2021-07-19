using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for button.
    /// </summary>
    public interface IHeadTrackerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> of head tracker.
        /// </summary>
        IPoseTrackerSoftwareHandler Pose { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Direction"/> to software.
        /// </summary>
        IProduction<Space3D.Direction> Direction { get; }
    }
}
