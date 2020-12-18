using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventOutputHandler :
        ISoftwareHandler
    {
        IPulseEventOutputHandler Touch { get; }

        IPulseEventOutputHandler Pull { get; }
    }
}
