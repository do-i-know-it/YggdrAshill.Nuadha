using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITriggerConfiguration
    {
        IProduction<Touch> Touch { get; }

        IProduction<Pull> Pull { get; }
    }
}
