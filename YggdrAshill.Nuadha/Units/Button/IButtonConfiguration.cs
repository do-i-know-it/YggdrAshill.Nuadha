using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IButtonConfiguration
    {
        IGenerator<Touch> Touch { get; }

        IGenerator<Push> Push { get; }
    }
}
