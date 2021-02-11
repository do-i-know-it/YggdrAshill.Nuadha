using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Notates <typeparamref name="TSignal"/> as <see cref="Note"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notate.
    /// </typeparam>
    public interface INotation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Notates <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="ISignal"/> to notate.
        /// </param>
        /// <returns>
        /// Description of <see cref="ISignal"/> as <see cref="Note"/>.
        /// </returns>
        Note Notate(TSignal signal);
    }
}
