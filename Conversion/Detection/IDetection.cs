using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Detects <see cref="Pulse"/> with condition.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect <see cref="Pulse"/>.
    /// </typeparam>
    public interface IDetection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Detects <see cref="Pulse"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="ISignal"/> to detect <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// True if condition is satisfied by <typeparamref name="TSignal"/>.
        /// </returns>
        bool Detect(TSignal signal);
    }
}
