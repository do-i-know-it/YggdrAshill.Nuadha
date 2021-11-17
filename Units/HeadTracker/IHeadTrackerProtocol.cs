using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public interface IHeadTrackerProtocol :
        IModule,
        IProtocol<IHeadTrackerHardware, IHeadTrackerSoftware>
    {
        /// <summary>
        /// <see cref="IPoseTrackerProtocol"/> of head tracker.
        /// </summary>
        IPoseTrackerProtocol Pose { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Direction"/>.
        /// </summary>
        IPropagation<Space3D.Direction> Direction { get; }
    }
}
