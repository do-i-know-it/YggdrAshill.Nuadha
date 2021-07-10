using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Connects <typeparamref name="THandler"/> to emit some types of <see cref="ISignal"/>.
    /// </summary>
    /// <typeparam name="THandler">
    /// Type of <see cref="IHandler"/> to ignite.
    /// </typeparam>
    public interface IIgnition<THandler> :
        IConnection<THandler>,
        IEmission,
        IDisposable
        where THandler : IHandler
    {

    }
}
