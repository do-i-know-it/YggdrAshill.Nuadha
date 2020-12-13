using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IStickConfiguration :
        IButtonConfiguration
    {
        IGenerator<Tilt> Tilt { get; }
    }
}
