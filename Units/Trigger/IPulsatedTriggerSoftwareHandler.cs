using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHandler"/> for software for trigger pulsated.
    /// </summary>
    public interface IPulsatedTriggerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// Sends <see cref="Pulse"/> of <see cref="Signals.Pull"/> to software.
        /// </summary>
        IProduction<Pulse> Pull { get; }
    }
}
