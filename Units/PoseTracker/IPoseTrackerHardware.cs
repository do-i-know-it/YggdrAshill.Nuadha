using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pose tracker as hardware.
    /// </summary>
    public interface IPoseTrackerHardware :
        IModule
    {
        /// <summary>
        /// Sends <see cref="Space3D.Position"/> to software.
        /// </summary>
        IProduction<Space3D.Position> Position { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Rotation"/> to software.
        /// </summary>
        IProduction<Space3D.Rotation> Rotation { get; }
    }
}
