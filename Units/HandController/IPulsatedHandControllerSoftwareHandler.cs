using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for hand controller pulsated.
    /// </summary>
    public interface IPulsatedHandControllerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IPulsatedStickSoftwareHandler"/> for software.
        /// </summary>
        IPulsatedStickSoftwareHandler Thumb { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftwareHandler"/> for software.
        /// </summary>
        IPulsatedTriggerSoftwareHandler IndexFinger { get; }

        /// <summary>
        /// <see cref="IPulsatedTriggerSoftwareHandler"/> for software.
        /// </summary>
        IPulsatedTriggerSoftwareHandler HandGrip { get; }
    }
}
