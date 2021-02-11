using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IStickConfiguration :
        IButtonConfiguration
    {
        IGeneration<Tilt> Tilt { get; }
    }
}
