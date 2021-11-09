namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration of <see cref="HandController"/>.
    /// </summary>
    public interface IHandControllerConfiguration
    {
        /// <summary>
        /// <see cref="IPoseTrackerConfiguration"/>.
        /// </summary>
        IPoseTrackerConfiguration Pose { get; }

        /// <summary>
        /// <see cref="IStickConfiguration"/> for <see cref="Thumb"/>.
        /// </summary>
        IStickConfiguration Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerConfiguration"/> for <see cref="IndexFinger"/>.
        /// </summary>
        ITriggerConfiguration IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerConfiguration"/> for <see cref="HandGrip"/>.
        /// </summary>
        ITriggerConfiguration HandGrip { get; }
    }
}
