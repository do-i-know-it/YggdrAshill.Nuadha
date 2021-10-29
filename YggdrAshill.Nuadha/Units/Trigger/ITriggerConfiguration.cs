using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITriggerConfiguration
    {
        IGeneration<Touch> Touch { get; }

        IGeneration<Pull> Pull { get; }
    }
}
