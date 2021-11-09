using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedButton :
        IButtonConfiguration
    {
        public static ImitatedButton Instance { get; } = new ImitatedButton();

        private ImitatedButton()
        {

        }

        /// <inheritdoc/>
        public IGeneration<Touch> Touch { get; } = Generate.Signal(() => Signals.Touch.Disabled);

        /// <inheritdoc/>
        public IGeneration<Push> Push { get; } = Generate.Signal(() => Signals.Push.Disabled);
    }
}
