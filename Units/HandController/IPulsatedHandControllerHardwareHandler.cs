using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for hardware for hand controller pulsated.
    /// </summary>
    public interface IPulsatedHandControllerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPulsatedStickHardwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedStickHardwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedTriggerHardwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedTriggerHardwareHandler HandGrip { get; }
    }
}
