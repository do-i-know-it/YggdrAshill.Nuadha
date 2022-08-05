using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Calibrates <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to calibrate.
    /// </typeparam>
    public interface ICalibration<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Calibrates <paramref name="signal"/> with <paramref name="offset"/>.
        /// </summary>
        /// <param name="signal">
        /// Original <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="offset">
        /// Offset <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <typeparamref name="TSignal"/> calibrated.
        /// </returns>
        TSignal Calibrate(TSignal signal, TSignal offset);
    }
}
