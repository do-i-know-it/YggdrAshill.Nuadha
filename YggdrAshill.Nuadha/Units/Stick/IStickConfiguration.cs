using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IStickConfiguration
    {
        IGeneration<Touch> Touch { get; }

        IGeneration<Tilt> Tilt { get; }
    }
}
