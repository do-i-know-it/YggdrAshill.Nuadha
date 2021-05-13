using System;

namespace YggdrAshill.Nuadha.Signalization.Experimental
{
    /// <summary>
    /// Conducts <typeparamref name="TSignal"/> to each connected <see cref="IConsumption{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to conduct.
    /// </typeparam>
    /// <remarks>
    /// This is <see cref="IProduction{TSignal}"/> and <see cref="IEmission"/>.
    /// </remarks>
    public interface IConduction<TSignal> :
        IProduction<TSignal>,
        IEmission,
        IDisposable
        where TSignal : ISignal
    {

    }
}
