using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventOutputHandler :
        ISoftwareHandler
    {
        IPulseEventOutputHandler Touch { get; }

        IPulseEventOutputHandler Push { get; }
    }
}
