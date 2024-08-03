using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> to <see cref="IOutflow{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to send.
    /// </typeparam>
    public interface IInflow<out TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Imports <paramref name="outflow"/> to send <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="outflow">
        /// <see cref="IOutflow{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> to cancel sending.
        /// </returns>
        IDisposable Import(IOutflow<TSignal> outflow);
    }
}
