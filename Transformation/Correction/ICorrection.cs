using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Corrects <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to correct.
    /// </typeparam>
    public interface ICorrection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Corrects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to correct.
        /// </param>
        /// <returns>
        /// <typeparamref name="TSignal"/> corrected.
        /// </returns>
        TSignal Correct(TSignal signal);
    }
}
