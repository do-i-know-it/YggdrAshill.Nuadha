using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class Button :
        IButton
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Push> Push { get; }

        internal Button(IButtonConfiguration configuration)
        {
            Touch = new PropagationWithoutCache<Touch>().Transmit(configuration.Touch);

            Push = new PropagationWithoutCache<Push>().Transmit(configuration.Push);

        }
    }
}
