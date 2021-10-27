using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IButtonConfiguration
    {
        IGeneration<Touch> Touch { get; }

        IGeneration<Push> Push { get; }
    }
}
