using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IConfiguration<THandler>
        where THandler : IHandler
    {
        IEmission Connect(THandler handler);
    }
}
