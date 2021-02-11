using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Generates <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal"></typeparam>
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
