using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for hand controller.
    /// </summary>
    public interface IHandControllerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerSoftwareHandler"/> of hand controler.
        /// </summary>
        IPoseTrackerSoftwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IStickSoftwareHandler"/> of hand controler.
        /// </summary>
        IStickSoftwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerSoftwareHandler"/> of hand controler.
        /// </summary>
        ITriggerSoftwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerSoftwareHandler"/> of hand controler.
        /// </summary>
        ITriggerSoftwareHandler HandGrip { get; }
    }
}
