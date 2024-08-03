using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Transmits <typeparamref name="TSignal"/> to <see cref="IOutflow{TSignal}"/>s.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to transmit.
    /// </typeparam>
    public interface IFlow<TSignal> : IInflow<TSignal>, IOutflow<TSignal>, IDisposable
        where TSignal : ISignal
    {

    }
}
