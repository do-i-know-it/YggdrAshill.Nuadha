using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventInputHandler :
        IHardwareHandler
    {
        ITouchEventInputHandler Touch { get; }

        IPullEventInputHandler Pull { get; }
    }
}
