using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedTrigger :
        ITriggerConfiguration
    {
        public static ImitatedTrigger Instance { get; } = new ImitatedTrigger();

        private ImitatedTrigger()
        {

        }

        /// <inheritdoc/>
        public IGeneration<Touch> Touch { get; } = Generate.Signal(() => Signals.Touch.Disabled);

        /// <inheritdoc/>
        public IGeneration<Pull> Pull { get; } = Generate.Signal(() => new Pull(0.0f));
    }
}
