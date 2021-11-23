using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Notifies <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to notify.
    /// </typeparam>
    public interface INotification<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Notifies <typeparamref name="TSignal"/>.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> to notify.
        /// </param>
        /// <returns>
        /// True if <typeparamref name="TSignal"/> is notified.
        /// </returns>
        bool Notify(TSignal signal);
    }
}
