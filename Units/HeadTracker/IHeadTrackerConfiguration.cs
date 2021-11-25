using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration for head tracker.
    /// </summary>
    public interface IHeadTrackerConfiguration
    {
        /// <summary>
        /// <see cref="IPoseTrackerConfiguration"/> for pose.
        /// </summary>
        IPoseTrackerConfiguration Pose { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Space3D.Direction"/>.
        /// </summary>
        IGeneration<Space3D.Direction> Direction { get; }
    }
}
