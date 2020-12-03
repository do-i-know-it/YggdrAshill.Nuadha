using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IConnection<THandler>
        where THandler : IHandler
    {
        IDisconnection Connect(THandler handler);
    }
}
