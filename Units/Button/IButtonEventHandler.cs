using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventHandler :
        ISoftwareHandler
    {
        ITouchEventHandler Touch { get; }

        IPushEventHandler Push { get; }
    }
}
