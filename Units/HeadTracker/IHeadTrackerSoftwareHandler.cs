using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for button.
    /// </summary>
    public interface IHeadTrackerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> for software.
        /// </summary>
        IPoseTrackerSoftwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Space3D.Direction"/> to software.
        /// </summary>
        IProduction<Space3D.Direction> Direction { get; }
    }
}
