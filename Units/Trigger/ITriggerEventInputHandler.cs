using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerEventInputHandler :
        IHardwareHandler
    {
        IPulseEventInputHandler Touch { get; }

        IPulseEventInputHandler Pull { get; }
    }
}
