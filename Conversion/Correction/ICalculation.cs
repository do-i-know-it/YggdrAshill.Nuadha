using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Calculates <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to calculate.
    /// </typeparam>
    public interface ICalculation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Calculates <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="left">
        /// Left side to calculate.
        /// </param>
        /// <param name="right">
        /// Right side to calculate.
        /// </param>
        /// <returns>
        /// <typeparamref name="TSignal"/> calculated.
        /// </returns>
        TSignal Calculate(TSignal left, TSignal right);
    }
}
