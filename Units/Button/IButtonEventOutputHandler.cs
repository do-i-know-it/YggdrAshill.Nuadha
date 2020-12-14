using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventOutputHandler :
        ISoftwareHandler
    {
        ITouchEventOutputHandler Touch { get; }

        IPushEventOutputHandler Push { get; }
    }
}
