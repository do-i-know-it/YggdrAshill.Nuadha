using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerConfiguration
    {
        IGeneration<Touch> Touch { get; }

        IGeneration<Pull> Pull { get; }
    }
}
