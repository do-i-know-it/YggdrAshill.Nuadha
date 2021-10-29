using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Connects <typeparamref name="TModule"/> to emit some types of <see cref="ISignal"/>.
    /// </summary>
    /// <typeparam name="TModule">
    /// Type of <see cref="IModule"/> to ignite.
    /// </typeparam>
    public interface IIgnition<TModule> :
        IConnection<TModule>,
        IEmission,
        IDisposable
        where TModule : IModule
    {

    }
}
