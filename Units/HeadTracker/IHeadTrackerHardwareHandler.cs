using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for head tracker.
    /// </summary>
    public interface IHeadTrackerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> of head tracker.
        /// </summary>
        IPoseTrackerHardwareHandler Pose { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Direction"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Direction> Direction { get; }
    }
}
