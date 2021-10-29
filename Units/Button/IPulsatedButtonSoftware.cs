using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule"/> for pulsated button as software.
    /// </summary>
    public interface IPulsatedButtonSoftware :
        IModule
    {
        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Touch"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Touch { get; }

        /// <summary>
        /// Receives <see cref="Pulse"/> of <see cref="Signals.Push"/> sent from hardware.
        /// </summary>
        IConsumption<Pulse> Push { get; }
    }
}
