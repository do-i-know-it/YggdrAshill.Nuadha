using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHardware"/> for head tracker.
    /// </summary>
    public interface IHeadTrackerHardware :
        IHardware
    {
        /// <summary>
        /// Sends <see cref="Signals.Battery"/> to <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        IProduction<Battery> Battery { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> to <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        IProduction<Space3D.Pose> Pose { get; }
    }
}
