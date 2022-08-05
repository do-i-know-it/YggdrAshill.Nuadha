using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Evaluates <typeparamref name="TSignal"/> to notify.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to evaluate.
    /// </typeparam>
    public interface IEvaluation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Evaluates <paramref name="signal"/> with <paramref name="gauge"/>.
        /// </summary>
        /// <param name="signal">
        /// Original <typeparamref name="TSignal"/> to evaluate.
        /// </param>
        /// <param name="gauge">
        /// Expected <typeparamref name="TSignal"/> to evaluate.
        /// </param>
        /// <returns>
        /// True if <paramref name="signal"/> is evaluated.
        /// </returns>
        bool Evaluate(TSignal signal, TSignal gauge);
    }
}
