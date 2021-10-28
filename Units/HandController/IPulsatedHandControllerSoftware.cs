using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated hand controller as software.
    /// </summary>
    public interface IPulsatedHandControllerSoftware :
        IModule
    {
        /// <summary>
        /// <see cref="IPulsatedStickSoftware"/> of hand controler.
        /// </summary>
        IPulsatedStickSoftware Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftware"/> of hand controler.
        /// </summary>
        IPulsatedTriggerSoftware IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftware"/> of hand controler.
        /// </summary>
        IPulsatedTriggerSoftware HandGrip { get; }
    }
}
