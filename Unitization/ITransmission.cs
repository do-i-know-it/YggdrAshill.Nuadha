using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
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
