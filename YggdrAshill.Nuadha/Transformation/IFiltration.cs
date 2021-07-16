using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Filtrates <typeparamref name="TSignal"/> to correct.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to correct.
    /// </typeparam>
    public interface IFiltration<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Filtrates <typeparamref name="TSignal"/> to correct.
        /// </summary>
        /// <param name="current">
        /// <typeparamref name="TSignal"/> for current.
        /// </param>
        /// <param name="previous">
        /// <typeparamref name="TSignal"/> for previouse.
        /// </param>
        /// <returns>
        /// <typeparamref name="TSignal"/> for next.
        /// </returns>
        TSignal Filtrate(TSignal current, TSignal previous);
    }
}
