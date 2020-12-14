using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventInputHandler :
        IHardwareHandler
    {
        ITouchEventInputHandler Touch { get; }

        IPushEventInputHandler Push { get; }
    }
}
