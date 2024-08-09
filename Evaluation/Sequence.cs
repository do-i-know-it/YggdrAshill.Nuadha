using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for sequence of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of sequence.
    /// </typeparam>
    public readonly struct Sequence<TSignal> : ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Previous value of <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Previous { get; }

        /// <summary>
        /// Current value of <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Current { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="previous">
        /// <typeparamref name="TSignal"/> for <see cref="Previous"/>.
        /// </param>
        /// <param name="current">
        /// <typeparamref name="TSignal"/> for <see cref="Current"/>.
        /// </param>
        public Sequence(TSignal previous, TSignal current)
        {
            Previous = previous;
            Current = current;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Previous}: {Previous} -> {nameof(Current)}: {Current}";
        }
    }
}
