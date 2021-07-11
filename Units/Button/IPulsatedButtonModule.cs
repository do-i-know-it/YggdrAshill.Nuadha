using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedButtonModule
    {
        IPropagation<Pulse> Touch { get; }

        IPropagation<Pulse> Push { get; }
    }
}
