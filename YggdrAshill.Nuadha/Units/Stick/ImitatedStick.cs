using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="IStickConfiguration"/>.
    /// </summary>
    public sealed class ImitatedStick :
        IStickConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedStick"/> singleton.
        /// </summary>
        public static ImitatedStick Instance { get; } = new ImitatedStick();

        private ImitatedStick()
        {

        }

        /// <inheritdoc/>
        public IGeneration<Touch> Touch { get; } = Generate.Signal(() => Signals.Touch.Disabled);

        /// <inheritdoc/>
        public IGeneration<Tilt> Tilt { get; } = Generate.Signal(() => Signals.Tilt.Origin);
    }
}
