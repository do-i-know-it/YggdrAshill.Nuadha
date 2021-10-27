using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Samples
{
    /// <summary>
    /// <see cref="IButtonConfiguration"/> for sample application.
    /// </summary>
    internal sealed class Button :
        IButtonConfiguration
    {
        public IGeneration<Touch> Touch => Generation.Of(() => Signals.Touch.Enabled);

        public IGeneration<Push> Push => Generation.Of(() => Signals.Push.Disabled);
    }
}
