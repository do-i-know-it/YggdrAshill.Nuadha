using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public interface IHeadTrackerModule :
        IModule<IHeadTrackerHardware, IHeadTrackerSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Signals.Battery"/>.
        /// </summary>
        IPropagation<Battery> Battery { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Pose"/>.
        /// </summary>
        IPropagation<Space3D.Pose> Pose { get; }
    }
}
