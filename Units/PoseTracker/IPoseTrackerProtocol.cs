using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public interface IPoseTrackerProtocol :
        IModule,
        IProtocol<IPoseTrackerHardware, IPoseTrackerSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Space3D.Position"/>.
        /// </summary>
        IPropagation<Space3D.Position> Position { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Rotation"/>.
        /// </summary>
        IPropagation<Space3D.Rotation> Rotation { get; }
    }
}
