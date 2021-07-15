using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for pose tracker.
    /// </summary>
    public interface IPoseTrackerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Space3D.Position"/> to software.
        /// </summary>
        IProduction<Space3D.Position> Position { get; }

        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Space3D.Rotation"/> to software.
        /// </summary>
        IProduction<Space3D.Rotation> Rotation { get; }
    }
}
