using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventInputHandler :
        IHardwareHandler
    {
        IPulseEventInputHandler Touch { get; }

        IPulseEventInputHandler Push { get; }
    }
}
