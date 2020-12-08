using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonEventHandler :
        ISoftwareHandler
    {
        ITouchEventHandler Touch { get; }

        IPushEventHandler Push { get; }
    }
}
