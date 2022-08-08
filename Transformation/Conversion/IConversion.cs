using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public interface IConversion<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TInput"/> to convert.
        /// </param>
        /// <returns>
        /// <typeparamref name="TOutput"/> converted.
        /// </returns>
        TOutput Convert(TInput signal);
    }
}
