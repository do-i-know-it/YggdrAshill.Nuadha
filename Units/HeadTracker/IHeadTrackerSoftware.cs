using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for head tracker as software.
    /// </summary>
    public interface IHeadTrackerSoftware :
        IModule
    {
        /// <summary>
        /// <see cref="IPoseTrackerSoftware"/> of head tracker.
        /// </summary>
        IPoseTrackerSoftware Pose { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Direction"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Direction> Direction { get; }
    }
}
