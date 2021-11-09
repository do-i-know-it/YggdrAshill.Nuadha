namespace YggdrAshill.Nuadha
{
    public sealed class ImitatedHandController :
        IHandControllerConfiguration
    {
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
