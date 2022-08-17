using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for accuracy of <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> for accuracy.
    /// </typeparam>
    public struct Accuracy<TSignal> :
        ISignal
        where TSignal : ISignal
    {
        /// <summary>
        /// Original <typeparamref name="TSignal"/>.
        /// </summary>
        public TSignal Original { get; }

        /// <summary>
        /// Error of <typeparamref name="TSignal"/> contained in <see cref="Original"/>.
        /// </summary>
        public TSignal Error { get; }

        public Accuracy(TSignal original, TSignal error)
        {
            Original = original;

            Error = error;
        }
    }
}
