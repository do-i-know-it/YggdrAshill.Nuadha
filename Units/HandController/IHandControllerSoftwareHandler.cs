using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for hand controller.
    /// </summary>
    public interface IHandControllerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerSoftwareHandler"/> for software.
        /// </summary>
        IPoseTrackerSoftwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IStickSoftwareHandler"/> for software.
        /// </summary>
        IStickSoftwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerSoftwareHandler"/> for software.
        /// </summary>
        ITriggerSoftwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerSoftwareHandler"/> for software.
        /// </summary>
        ITriggerSoftwareHandler HandGrip { get; }
    }
}
