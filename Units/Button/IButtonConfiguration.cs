using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonConfiguration
    {
        IGeneration<Touch> Touch { get; }

        IGeneration<Push> Push { get; }
    }
}
