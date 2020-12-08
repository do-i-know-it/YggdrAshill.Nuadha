using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITriggerConfiguration
    {
        ISource<Touch> Touch { get; }

        ISource<Pull> Pull { get; }
    }
}
