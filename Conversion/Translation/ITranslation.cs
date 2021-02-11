using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> for input.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> for output.
    /// </typeparam>
    public interface ITranslation<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        /// <summary>
        /// Translates <typeparamref name="TInput"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="ISignal"/> for input.
        /// </param>
        /// <returns>
        /// <see cref="ISignal"/> for output.
        /// </returns>
        TOutput Translate(TInput signal);
    }
}
