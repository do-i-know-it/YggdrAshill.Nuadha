using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for hand controller.
    /// </summary>
    public interface IHandControllerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> of hand controller.
        /// </summary>
        IPoseTrackerHardwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IStickHardwareHandler"/> of hand controller.
        /// </summary>
        IStickHardwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerHardwareHandler"/> of hand controller.
        /// </summary>
        ITriggerHardwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerHardwareHandler"/> of hand controller.
        /// </summary>
        ITriggerHardwareHandler HandGrip { get; }
    }
}
