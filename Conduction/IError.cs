using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines error of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of error.
    /// </typeparam>
    public interface IError<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Error of <typeparamref name="TSignal"/>.
        /// </summary>
        TSignal Signal { get; }
    }
}
