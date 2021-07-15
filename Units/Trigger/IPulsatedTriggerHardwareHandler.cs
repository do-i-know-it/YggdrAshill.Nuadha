using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for trigger pulsated.
    /// </summary>
    public interface IPulsatedTriggerHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Pull"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Pull { get; }
    }
}
