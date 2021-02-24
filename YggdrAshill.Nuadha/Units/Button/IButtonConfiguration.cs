using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IButtonConfiguration
    {
        IProduction<Touch> Touch { get; }

        IProduction<Push> Push { get; }
    }
}
