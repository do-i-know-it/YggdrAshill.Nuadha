using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Detects <see cref="Notice"/> of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public interface ICondition<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Checks this is satisfied by <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to detect.
        /// </param>
        /// <returns>
        /// True if this is satisfied.
        /// </returns>
        bool IsSatisfiedBy(TSignal signal);
    }
}
