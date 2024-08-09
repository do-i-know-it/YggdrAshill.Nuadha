using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Threshold value of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of threshold.
    /// </typeparam>
    public interface IThreshold<out TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Threshold value of <typeparamref name="TSignal"/>.
        /// </summary>
        TSignal Value { get; }
    }
}
