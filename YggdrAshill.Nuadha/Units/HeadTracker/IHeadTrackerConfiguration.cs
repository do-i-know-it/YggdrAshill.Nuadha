using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration of <see cref="HeadTracker"/>.
    /// </summary>
    public interface IHeadTrackerConfiguration
    {
        /// <summary>
        /// <see cref="IPoseTrackerConfiguration"/>.
        /// </summary>
        IPoseTrackerConfiguration Pose { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Space3D.Direction"/>.
        /// </summary>
        IGeneration<Space3D.Direction> Direction { get; }
    }
}
