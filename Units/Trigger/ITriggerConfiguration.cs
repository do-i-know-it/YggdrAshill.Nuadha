using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration for trigger.
    /// </summary>
    public interface ITriggerConfiguration
    {
        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Touch"/>.
        /// </summary>
        IGeneration<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IGeneration{TSignal}"/> to generate <see cref="Signals.Pull"/>.
        /// </summary>
        IGeneration<Pull> Pull { get; }
    }
}
