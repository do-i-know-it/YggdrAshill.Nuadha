using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class Button :
        IButton
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Push> Push { get; }

        internal Button(IButtonModule module, IButtonConfiguration configuration)
        {
            Touch = module.Touch.Transmit(configuration.Touch);

            Push = module.Push.Transmit(configuration.Push);

        }
    }
}
