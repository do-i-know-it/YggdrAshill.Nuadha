using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for hand controller pulsated.
    /// </summary>
    public interface IPulsatedHandControllerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPulsatedStickHardwareHandler"/> for hardware.
        /// </summary>
        IPulsatedStickHardwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardwareHandler"/> for hardware.
        /// </summary>
        IPulsatedTriggerHardwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardwareHandler"/> for hardware.
        /// </summary>
        IPulsatedTriggerHardwareHandler HandGrip { get; }
    }
}
