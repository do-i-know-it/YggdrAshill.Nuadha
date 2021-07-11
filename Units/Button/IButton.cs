using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButton
    {
        ITransmission<Touch> Touch { get; }

        ITransmission<Push> Push { get; }
    }
}
