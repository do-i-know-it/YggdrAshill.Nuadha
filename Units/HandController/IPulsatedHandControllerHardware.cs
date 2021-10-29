using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated hand controller as hardware.
    /// </summary>
    public interface IPulsatedHandControllerHardware :
        IModule
    {
        /// <summary>
        /// <see cref="IPulsatedStickHardware"/> of hand controler.
        /// </summary>
        IPulsatedStickHardware Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardware"/> of hand controler.
        /// </summary>
        IPulsatedTriggerHardware IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerHardware"/> of hand controler.
        /// </summary>
        IPulsatedTriggerHardware HandGrip { get; }
    }
}
