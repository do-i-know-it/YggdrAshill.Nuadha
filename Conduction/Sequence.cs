using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for sequence of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of sequence.
    /// </typeparam>
    public struct Sequence<TSignal> :
        ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Previous <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Previous { get; }

        /// <summary>
        /// Current <typeparamref name="TSignal"/>.
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
            return $"{Previous} -> {Current}";
        }

        /// <summary>
        /// Converts explicitly <paramref name="signal"/> to <see cref="Sequence{TSignal}"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Sequence{TSignal}"/> converted.
        /// </returns>
        public static explicit operator Sequence<TSignal>(TSignal signal)
        {
            return new Sequence<TSignal>(signal, signal);
        }
    }
}
