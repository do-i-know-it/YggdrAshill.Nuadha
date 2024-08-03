namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Sends <typeparamref name="TSignal"/> received.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> received to send.
    /// </typeparam>
    public interface IOutflow<in TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Exports <paramref name="signal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to export.
        /// </param>
        void Export(TSignal signal);
    }
}
