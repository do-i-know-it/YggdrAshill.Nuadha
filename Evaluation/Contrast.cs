using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for contrast of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of contrast.
    /// </typeparam>
    public readonly struct Contrast<TSignal> : ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Expected value of <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Expected { get; }

        /// <summary>
        /// Actual value of <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Actual { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expected">
        /// <typeparamref name="TSignal"/> for <see cref="Expected"/>.
        /// </param>
        /// <param name="actual">
        /// <typeparamref name="TSignal"/> for <see cref="Actual"/>.
        /// </param>
        public Contrast(TSignal expected, TSignal actual)
        {
            Expected = expected;
            Actual = actual;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Expected)}: {Expected}, {nameof(Actual)}: {Actual}";
        }
    }
}
