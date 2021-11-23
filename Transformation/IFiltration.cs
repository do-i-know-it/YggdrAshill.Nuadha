using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Filtrates <typeparamref name="TSignal"/> to correct.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to filtrate.
    /// </typeparam>
    public interface IFiltration<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Filtrates <typeparamref name="TSignal"/> to correct.
        /// </summary>
        /// <param name="current">
        /// Current <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="previous">
        /// Previouis <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// Next <typeparamref name="TSignal"/>.
        /// </returns>
        TSignal Filtrate(TSignal current, TSignal previous);
    }
}
