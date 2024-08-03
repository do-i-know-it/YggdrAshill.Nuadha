using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for accuracy of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of accuracy.
    /// </typeparam>
    public readonly struct Accuracy<TSignal> : ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Original value of <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Original { get; }

        /// <summary>
        /// Offset value of <typeparamref name="TSignal"/> contained in <see cref="Original"/>.
        /// </summary>
        public TSignal Offset { get; }

        public Accuracy(TSignal original, TSignal offset)
        {
            Original = original;
            Offset = offset;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Original)}: {Original}, {nameof(Offset)}: {Offset}";
        }
    }
}
