using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerPulsation
    {
        ITranslation<Touch, Pulse> Touch { get; }

        ITranslation<Pull, Pulse> Pull { get; }
    }
}
