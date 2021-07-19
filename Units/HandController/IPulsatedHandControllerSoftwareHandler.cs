using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for hand controller pulsated.
    /// </summary>
    public interface IPulsatedHandControllerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPulsatedStickSoftwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedStickSoftwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedTriggerSoftwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftwareHandler"/> of hand controler.
        /// </summary>
        IPulsatedTriggerSoftwareHandler HandGrip { get; }
    }
}
