using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Starts to emit <see cref="ISignal"/>.
    /// </summary>
    public interface IIgnition
    {
        /// <summary>
        /// Starts to emit.
        /// </summary>
        /// <returns>
        /// <see cref="IEmission"/> to emit.
        /// </returns>
        IEmission Ignite();
    }
}
