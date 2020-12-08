using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventHandler :
        ISoftwareHandler
    {
        ITouchEventHandler Touch { get; }

        IPullEventHandler Pull { get; }
    }
}
