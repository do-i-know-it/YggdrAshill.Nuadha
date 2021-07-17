using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class IgniteHandController :
        IIgnition<IHandControllerHardwareHandler>
    {
        private readonly IgnitePoseTracker pose;

        private readonly IgniteStick thumb;

        private readonly IgniteTrigger indexFinger;

        private readonly IgniteTrigger handGrip;

        internal IgniteHandController(HandControllerModule module, IHandControllerConfiguration configuration)
        {
            pose = new IgnitePoseTracker(module.Pose, configuration.Pose);

            thumb = new IgniteStick(module.Thumb, configuration.Thumb);

            indexFinger = new IgniteTrigger(module.IndexFinger, configuration.IndexFinger);

            handGrip = new IgniteTrigger(module.HandGrip, configuration.HandGrip);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var composite = new CompositeCancellation();

            pose.Connect(handler.Pose).Synthesize(composite);
            thumb.Connect(handler.Thumb).Synthesize(composite);
            indexFinger.Connect(handler.IndexFinger).Synthesize(composite);
            handGrip.Connect(handler.HandGrip).Synthesize(composite);

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
