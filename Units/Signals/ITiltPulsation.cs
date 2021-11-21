using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltPulsation
    {
        ITranslation<Tilt, Pulse> Distance { get; }

        ITranslation<Tilt, Pulse> Left { get; }

        ITranslation<Tilt, Pulse> Right { get; }

        ITranslation<Tilt, Pulse> Forward { get; }

        ITranslation<Tilt, Pulse> Backward { get; }
    }
}
