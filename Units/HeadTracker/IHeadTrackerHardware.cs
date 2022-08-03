using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for head tracker as hardware.
    /// </summary>
    public interface IHeadTrackerHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> to software.
        /// </summary>
        IProduction<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Direction"/> to software.
        /// </summary>
        IProduction<Space3D.Direction> Direction { get; }
    }
}
