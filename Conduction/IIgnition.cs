using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Connects <typeparamref name="TModule"/> to emit.
    /// </summary>
    /// <typeparam name="TModule">
    /// Type of <see cref="IModule"/> to connect.
    /// </typeparam>
    public interface IIgnition<TModule> :
        IConnection<TModule>,
        IEmission,
        IDisposable
        where TModule : IModule
    {

    }
}
