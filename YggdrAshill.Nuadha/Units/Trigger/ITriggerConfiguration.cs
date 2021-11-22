using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration of <see cref="Trigger"/>.
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
