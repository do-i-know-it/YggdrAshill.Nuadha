using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    internal sealed class HandController :
        IHandController
    {
        public IPoseTracker Pose { get; }

        public IStick Thumb { get; }

        public ITrigger IndexFinger { get; }

        public ITrigger HandGrip { get; }

        internal HandController(IHandControllerConfiguration configuration)
        {
            Pose = new PoseTracker(configuration.Pose);

            Thumb = new Stick(configuration.Thumb);

            IndexFinger = new Trigger(configuration.IndexFinger);

            HandGrip = new Trigger(configuration.HandGrip);
        }
    }
}
