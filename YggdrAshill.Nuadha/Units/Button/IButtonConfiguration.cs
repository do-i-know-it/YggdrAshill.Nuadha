using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration of <see cref="Button"/>.
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
