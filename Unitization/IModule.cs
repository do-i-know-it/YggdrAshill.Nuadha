namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Defines module being <see cref="IHardware"/> and <see cref="ISoftware"/>.
    /// </summary>
    /// <typeparam name="THardware">
    /// Type of <see cref="IHardware"/> for module.
    /// </typeparam>
    /// <typeparam name="TSoftware">
    /// Type of <see cref="ISoftware"/> for module.
    /// </typeparam>
    public interface IModule<THardware, TSoftware>
        where THardware : IHardware
        where TSoftware : ISoftware
    {
        /// <summary>
        /// <typeparamref name="THardware"/> for module.
        /// </summary>
        THardware Hardware { get; }

        /// <summary>
        /// <typeparamref name="TSoftware"/> for module.
        /// </summary>
        TSoftware Software { get; }
    }
}
