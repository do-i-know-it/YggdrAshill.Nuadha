using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    /// <summary>
    /// Converts <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public interface IPulsation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="Pulse"/> converted.
        /// </returns>
        Pulse Pulsate(TSignal signal);
    }
}
