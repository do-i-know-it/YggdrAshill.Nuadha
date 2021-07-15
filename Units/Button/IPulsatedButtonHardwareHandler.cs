using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for button pulsated.
    /// </summary>
    public interface IPulsatedButtonHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Push"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Push { get; }
    }
}
