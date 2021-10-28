using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for hand controller as hardware.
    /// </summary>
    public interface IHandControllerHardware :
        IModule
    {
        /// <summary>
        /// <see cref="IPoseTrackerHardware"/> of hand controler.
        /// </summary>
        IPoseTrackerHardware Pose { get; }

        /// <summary>
        /// <see cref="IStickHardware"/> of hand controler.
        /// </summary>
        IStickHardware Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerHardware"/> of hand controler.
        /// </summary>
        ITriggerHardware IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerHardware"/> of hand controler.
        /// </summary>
        ITriggerHardware HandGrip { get; }
    }
}
