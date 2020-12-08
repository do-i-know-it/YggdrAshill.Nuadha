using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IButtonConfiguration
    {
        ISource<Touch> Touch { get; }

        ISource<Push> Push { get; }
    }
}
