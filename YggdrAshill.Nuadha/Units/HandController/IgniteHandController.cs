using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteHandController :
        IIgnition<IHandControllerSoftware>
    {
        private readonly IgnitePoseTracker pose;

        private readonly IgniteStick thumb;

        private readonly IgniteTrigger indexFinger;

        private readonly IgniteTrigger handGrip;

        internal IgniteHandController(HandController protocol, IHandControllerConfiguration configuration)
        {
            pose = new IgnitePoseTracker(protocol.Pose, configuration.Pose);

            thumb = new IgniteStick(protocol.Thumb, configuration.Thumb);

            indexFinger = new IgniteTrigger(protocol.IndexFinger, configuration.IndexFinger);

            handGrip = new IgniteTrigger(protocol.HandGrip, configuration.HandGrip);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IHandControllerSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            var composite = new CompositeCancellation();

            pose.Connect(module.Pose).Synthesize(composite);
            thumb.Connect(module.Thumb).Synthesize(composite);
            indexFinger.Connect(module.IndexFinger).Synthesize(composite);
            handGrip.Connect(module.HandGrip).Synthesize(composite);

            return composite;
        }

        /// <inheritdoc/>
        public void Emit()
        {
            pose.Emit();

            thumb.Emit();

            indexFinger.Emit();

            handGrip.Emit();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            pose.Dispose();

            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }
    }
}
