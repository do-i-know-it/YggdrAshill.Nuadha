using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for pose tracker.
    /// </summary>
    public interface IPoseTrackerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// Receives <see cref="Space3D.Position"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Position> Position { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Rotation"/> sent from hardware.
        /// </summary>
        IConsumption<Space3D.Rotation> Rotation { get; }
    }
}
