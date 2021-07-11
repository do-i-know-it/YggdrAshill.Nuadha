using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITrigger
    {
        ITransmission<Touch> Touch { get; }

        ITransmission<Pull> Pull { get; }
    }
}
