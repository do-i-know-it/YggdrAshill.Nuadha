using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class Stick :
        IStick
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Tilt> Tilt { get; }

        internal Stick(IStickConfiguration configuration)
        {
            Touch = new PropagationWithoutCache<Touch>().Transmit(configuration.Touch);

            Tilt = new PropagationWithoutCache<Tilt>().Transmit(configuration.Tilt);
        }
    }
}
