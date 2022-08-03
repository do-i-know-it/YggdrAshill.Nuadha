using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration of hand controller.
    /// </summary>
    public interface IHandControllerConfiguration
    {
        /// <summary>
        /// Generates <see cref="Space3D.Pose"/> to send.
        /// </summary>
        IGeneration<Space3D.Pose> Pose { get; }

        /// <summary>
        /// Generates <see cref="Stick"/> of thumb to send.
        /// </summary>
        IGeneration<Stick> Thumb { get; }

        /// <summary>
        /// Generates <see cref="Trigger"/> of index finger to send.
        /// </summary>
        IGeneration<Trigger> IndexFinger { get; }

        /// <summary>
        /// Generates <see cref="Trigger"/> of hand grip to send.
        /// </summary>
        IGeneration<Trigger> HandGrip { get; }
    }
}
