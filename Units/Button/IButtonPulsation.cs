using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonPulsation
    {
        ITranslation<Touch, Pulse> Touch { get; }

        ITranslation<Push, Pulse> Push { get; }
    }
}
