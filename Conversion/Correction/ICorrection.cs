using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Corrects <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> for correction.
    /// </typeparam>
    public interface ICorrection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Corrects <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="ISignal"/> to correct.
        /// </param>
        /// <returns>
        /// <see cref="ISignal"/> corrected.
        /// </returns>
        TSignal Correct(TSignal signal);
    }
}
