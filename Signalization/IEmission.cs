namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Token to send <see cref="ISignal"/>.
    /// </summary>
    public interface IEmission
    {
        /// <summary>
        /// Sends <see cref="ISignal"/>.
        /// </summary>
        void Emit();
    }
}
