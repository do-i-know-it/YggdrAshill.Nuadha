using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for hardware for button.
    /// </summary>
    public interface IButtonHardwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IConsumption{TSignal}"/> to consume <see cref="Signals.Push"/> sent from hardware.
        /// </summary>
        IConsumption<Push> Push { get; }
    }
}
