using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedStick :
        IStickConfiguration
    {
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
