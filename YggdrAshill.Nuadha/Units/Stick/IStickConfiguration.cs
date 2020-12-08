using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IStickConfiguration :
        IButtonConfiguration
    {
        ISource<Tilt> Tilt { get; }
    }
}
