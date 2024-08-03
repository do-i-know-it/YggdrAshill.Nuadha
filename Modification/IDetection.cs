using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Modification
{
    /// <summary>
    /// Defines how to detect <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public interface IDetection<in TSignal>
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
