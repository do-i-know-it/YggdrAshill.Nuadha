using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for hand controller as software.
    /// </summary>
    public interface IHandControllerSoftware :
        IModule
    {
        /// <summary>
        /// <see cref="IPoseTrackerSoftware"/> of hand controller.
        /// </summary>
        IPoseTrackerSoftware Pose { get; }

        /// <summary>
        /// <see cref="IStickSoftware"/> of hand controller.
        /// </summary>
        IStickSoftware Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerSoftware"/> of hand controller.
        /// </summary>
        ITriggerSoftware IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerSoftware"/> of hand controller.
        /// </summary>
        ITriggerSoftware HandGrip { get; }
    }
}
