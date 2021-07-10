using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStick
    {
        ITransmission<Touch> Touch { get; }

        ITransmission<Tilt> Tilt { get; }
    }
}
