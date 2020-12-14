using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventOutputHandler :
        ISoftwareHandler
    {
        ITouchEventOutputHandler Touch { get; }

        IPullEventOutputHandler Pull { get; }
    }
}
