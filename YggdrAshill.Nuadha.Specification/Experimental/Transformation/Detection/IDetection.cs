using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    /// <summary>
    /// Detects <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public interface IDetection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Detects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to detect.
        /// </param>
        /// <returns>
        /// True if <typeparamref name="TSignal"/> is detected.
        /// </returns>
        bool Detect(TSignal signal);
    }
}
