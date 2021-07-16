using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for head tracker.
    /// </summary>
    public interface IHeadTrackerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> for hardware.
        /// </summary>
        IPoseTrackerHardwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Space3D.Direction"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Direction> Direction { get; }
    }
}
