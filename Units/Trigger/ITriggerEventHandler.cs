using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventHandler :
        ISoftwareHandler
    {
        ITouchEventHandler Touch { get; }

        IPullEventHandler Pull { get; }
    }
}
