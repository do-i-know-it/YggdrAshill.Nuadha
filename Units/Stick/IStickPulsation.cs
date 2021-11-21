using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickPulsation
    {
        ITranslation<Touch, Pulse> Touch { get; }

        ITiltPulsation Tilt { get; }
    }
}
