using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class Stick :
        IStick
    {
        public ITransmission<Touch> Touch { get; }

        public ITransmission<Tilt> Tilt { get; }

        internal Stick(IStickModule module, IStickConfiguration configuration)
        {
            Touch = module.Touch.Transmit(configuration.Touch);

            Tilt = module.Tilt.Transmit(configuration.Tilt);
        }
    }
}
