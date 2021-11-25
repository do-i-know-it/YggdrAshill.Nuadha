namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines configuration of hand controller.
    /// </summary>
    public interface IHandControllerConfiguration
    {
        /// <summary>
        /// <see cref="IPoseTrackerConfiguration"/>.
        /// </summary>
        IPoseTrackerConfiguration Pose { get; }

        /// <summary>
        /// <see cref="IStickConfiguration"/> for thumb.
        /// </summary>
        IStickConfiguration Thumb { get; }

        /// <summary>
        /// <see cref="ITriggerConfiguration"/> for index finger.
        /// </summary>
        ITriggerConfiguration IndexFinger { get; }

        /// <summary>
        /// <see cref="ITriggerConfiguration"/> for hand grip.
        /// </summary>
        ITriggerConfiguration HandGrip { get; }
    }
}
