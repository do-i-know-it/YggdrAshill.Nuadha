using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerModule
    {
        IPropagation<Touch> Touch { get; }

        IPropagation<Pull> Pull { get; }
    }
}
