namespace YggdrAshill.Nuadha.Units
{
    internal sealed class HandController :
        IHandController
    {
        public IPoseTracker Pose { get; }

        public IStick Thumb { get; }

        public ITrigger IndexFinger { get; }

        public ITrigger HandGrip { get; }

        internal HandController(IHandControllerModule module, IHandControllerConfiguration configuration)
        {
            Pose = new PoseTracker(module.Pose, configuration.Pose);

            Thumb = new Stick(module.Thumb, configuration.Thumb);

            IndexFinger = new Trigger(module.IndexFinger, configuration.IndexFinger);

            HandGrip = new Trigger(module.HandGrip, configuration.HandGrip);
        }
    }
}
