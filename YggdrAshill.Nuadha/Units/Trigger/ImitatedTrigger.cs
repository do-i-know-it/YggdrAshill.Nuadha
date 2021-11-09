using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="ITriggerConfiguration"/>.
    /// </summary>
    public sealed class ImitatedTrigger :
        ITriggerConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedTrigger"/> singleton.
        /// </summary>
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
