using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Generates <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to generate.
    /// </typeparam>
    public interface IGeneration<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Generates <typeparamref name="TSignal"/>.
        /// </summary>
        /// <returns>
        /// <typeparamref name="TSignal"/> generated.
        /// </returns>
        TSignal Generate();
    }
}
