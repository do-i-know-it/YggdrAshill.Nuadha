using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for analysis of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> of analysis.
    /// </typeparam>
    public struct Analysis<TSignal> :
        ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Expeted <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Expected { get; }

        /// <summary>
        /// Actual <typeparamref name="TSignal"/>.
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
        public Analysis(TSignal expected, TSignal actual)
        {
            Expected = expected;

            Actual = actual;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Expected}/{Actual}";
        }
    }
}
