using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Offset value of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of offset.
    /// </typeparam>
    public interface IOffset<out TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Offset value of <typeparamref name="TSignal"/>.
        /// </summary>
        TSignal Value { get; }
    }
}
