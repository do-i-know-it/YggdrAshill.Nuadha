using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines pulsation for button.
    /// </summary>
    public interface IButtonPulsation
    {
        /// <summary>
        /// Converts <see cref="Signals.Touch"/> into <see cref="Pulse"/>.
        /// </summary>
        ITranslation<Touch, Pulse> Touch { get; }

        /// <summary>
        /// Converts <see cref="Signals.Push"/> into <see cref="Pulse"/>.
        /// </summary>
        ITranslation<Push, Pulse> Push { get; }
    }
}
