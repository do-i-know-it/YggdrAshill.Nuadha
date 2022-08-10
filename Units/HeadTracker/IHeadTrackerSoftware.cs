using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Monitorization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="ISoftware"/> for head tracker.
    /// </summary>
    public interface IHeadTrackerSoftware :
        ISoftware
    {
        /// <summary>
        /// Receives <see cref="Monitorization.Battery"/> sent from <see cref="IHeadTrackerHardware"/>.
        /// </summary>
        IConsumption<Battery> Battery { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> sent from <see cref="IHeadTrackerHardware"/>.
        /// </summary>
        IConsumption<Space3D.Pose> Pose { get; }
    }
}
