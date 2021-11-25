using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines pulsation for stick.
    /// </summary>
    public interface IStickPulsation
    {
        /// <summary>
        /// Converts <see cref="Signals.Touch"/> into <see cref="Pulse"/>.
        /// </summary>
        ITranslation<Touch, Pulse> Touch { get; }

        /// <summary>
        /// <see cref="ITiltPulsation"/> for <see cref="Signals.Tilt"/>.
        /// </summary>
        ITiltPulsation Tilt { get; }
    }
}
