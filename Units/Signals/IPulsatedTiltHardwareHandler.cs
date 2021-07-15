using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for <see cref="Signals.Tilt"/> pulsated.
    /// </summary>
    public interface IPulsatedTiltHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Tilt.Distance"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Distance { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Tilt.Left"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Left { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Tilt.Right"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Right { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Tilt.Upward"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Forward { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Pulse"/> of <see cref="Signals.Tilt.Downward"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Backward { get; }
    }
}
