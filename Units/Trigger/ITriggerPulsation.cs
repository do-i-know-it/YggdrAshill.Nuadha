using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines pulsation for trigger.
    /// </summary>
    public interface ITriggerPulsation
    {
        /// <summary>
        /// Converts <see cref="Signals.Touch"/> into <see cref="Pulse"/>.
        /// </summary>
        ITranslation<Touch, Pulse> Touch { get; }

        /// <summary>
        /// Converts <see cref="Signals.Pull"/> into <see cref="Pulse"/>.
        /// </summary>
        ITranslation<Pull, Pulse> Pull { get; }
    }
}
