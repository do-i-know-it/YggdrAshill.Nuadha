using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha
{
    public interface IPulsatedTiltModule
    {
        IPropagation<Pulse> Distance { get; }

        IPropagation<Pulse> Left { get; }

        IPropagation<Pulse> Right { get; }

        IPropagation<Pulse> Forward { get; }

        IPropagation<Pulse> Backward { get; }
    }
}
