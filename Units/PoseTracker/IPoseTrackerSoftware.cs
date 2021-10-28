using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pose tracker as software.
    /// </summary>
    public interface IPoseTrackerSoftware :
        IModule
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
