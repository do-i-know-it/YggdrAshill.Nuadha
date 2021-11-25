using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines correction for pose tracker.
    /// </summary>
    public interface IPoseTrackerCorrection
    {
        /// <summary>
        /// Corrects <see cref="Space3D.Position"/>.
        /// </summary>
        ITranslation<Space3D.Position, Space3D.Position> Position { get; }

        /// <summary>
        /// Corrects <see cref="Space3D.Rotation"/>.
        /// </summary>
        ITranslation<Space3D.Rotation, Space3D.Rotation> Rotation { get; }
    }
}
