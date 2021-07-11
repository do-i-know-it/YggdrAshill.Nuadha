using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickModule
    {
        IPropagation<Touch> Touch { get; }

        IPropagation<Tilt> Tilt { get; }
    }
}
