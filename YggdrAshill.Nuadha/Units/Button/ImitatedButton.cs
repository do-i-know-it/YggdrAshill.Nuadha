using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="IButtonConfiguration"/>.
    /// </summary>
    public sealed class ImitatedButton :
        IButtonConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedButton"/> singleton.
        /// </summary>
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
