using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration for button.
    /// </summary>
    public interface IButtonConfiguration
    {
        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Touch"/>.
        /// </summary>
        IGeneration<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Push"/>.
        /// </summary>
        IGeneration<Push> Push { get; }
    }
}