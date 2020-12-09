using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITriggerConfiguration
    {
        IGenerator<Touch> Touch { get; }

        IGenerator<Pull> Pull { get; }
    }
}
