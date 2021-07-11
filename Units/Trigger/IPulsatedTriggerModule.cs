using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedTriggerModule
    {
        IPropagation<Pulse> Touch { get; }

        IPropagation<Pulse> Pull { get; }
    }
}
