using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Transmits <see cref="ISignal"/>s to <typeparamref name="TModule"/>.
    /// </summary>
    /// <typeparam name="TModule">
    /// Type of <see cref="IModule"/> to transmit.
    /// </typeparam>
    public interface ITransmission<TModule> :
        IConnection<TModule>,
        IEmission
        where TModule : IModule
    {
        
    }
}
