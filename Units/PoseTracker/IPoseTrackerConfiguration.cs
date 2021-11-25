using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration for pose tracker.
    /// </summary>
    public interface IPoseTrackerConfiguration
    {
        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Space3D.Position"/>.
        /// </summary>
        IGeneration<Space3D.Position> Position { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Space3D.Rotation"/>.
        /// </summary>
        IGeneration<Space3D.Rotation> Rotation { get; }
    }
}
