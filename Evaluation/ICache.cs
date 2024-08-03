using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Cached value of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> for cache.
    /// </typeparam>
    public interface ICache<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Cached value of <typeparamref name="TSignal"/>.
        /// </summary>
        TSignal Value { get; set; }
    }
}
