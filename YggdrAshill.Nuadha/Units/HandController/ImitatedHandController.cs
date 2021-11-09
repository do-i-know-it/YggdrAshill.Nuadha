namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="IHandControllerConfiguration"/>.
    /// </summary>
    public sealed class ImitatedHandController :
        IHandControllerConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedHandController"/> singleton.
        /// </summary>
        public static ImitatedHandController Instance { get; } = new ImitatedHandController();

        private ImitatedHandController()
        {

        }

        /// <inheritdoc/>
        public IPoseTrackerConfiguration Pose { get; } = ImitatedPoseTracker.Instance;

        /// <inheritdoc/>
        public IStickConfiguration Thumb { get; } = ImitatedStick.Instance;

        /// <inheritdoc/>
        public ITriggerConfiguration IndexFinger { get; } = ImitatedTrigger.Instance;

        /// <inheritdoc/>
        public ITriggerConfiguration HandGrip { get; } = ImitatedTrigger.Instance;
    }
}
