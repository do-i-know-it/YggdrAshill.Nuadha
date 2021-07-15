using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for trigger pulsated.
    /// </summary>
    public interface IPulsatedTriggerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Pulse"/> of <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Pulse"/> of <see cref="Signals.Pull"/> to software.
        /// </summary>
        IProduction<Pulse> Pull { get; }
    }
}
