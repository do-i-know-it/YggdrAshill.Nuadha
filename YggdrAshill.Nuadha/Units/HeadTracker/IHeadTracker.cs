using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration for head tracker.
    /// </summary>
    public interface IHeadTracker
    {
        /// <summary>
        /// Generates <see cref="Signals.Battery"/> to send.
        /// </summary>
        IGeneration<Battery> Battery { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Space3D.Pose"/>.
        /// </summary>
        IGeneration<Space3D.Pose> Pose { get; }
    }
}
