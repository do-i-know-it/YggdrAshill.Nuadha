using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for pose tracker.
    /// </summary>
    public interface IPoseTrackerSoftwareHandler :
        IHandler
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
