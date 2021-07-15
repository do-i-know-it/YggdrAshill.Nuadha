using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for hand controller.
    /// </summary>
    public interface IHandControllerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardwareHandler"/> for hardware.
        /// </summary>
        IPoseTrackerHardwareHandler Pose { get; }

        /// <summary>
        /// <see cref="IStickHardwareHandler"/> for hardware.
        /// </summary>
        IStickHardwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerHardwareHandler"/> for hardware.
        /// </summary>
        ITriggerHardwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerHardwareHandler"/> for hardware.
        /// </summary>
        ITriggerHardwareHandler HandGrip { get; }
    }
}
