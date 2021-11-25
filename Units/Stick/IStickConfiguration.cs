using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration for stick.
    /// </summary>
    public interface IStickConfiguration
    {
        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Touch"/>.
        /// </summary>
        IGeneration<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Tilt"/>.
        /// </summary>
        IGeneration<Tilt> Tilt { get; }
    }
}
