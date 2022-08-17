using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines target of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of target.
    /// </typeparam>
    public interface ITarget<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Target of <typeparamref name="TSignal"/>.
        /// </summary>
        TSignal Signal { get; }
    }
}
