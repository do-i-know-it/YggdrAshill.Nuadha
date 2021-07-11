using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class IgniteHandController :
        IIgnition<IHandControllerHardwareHandler>
    {
        private readonly IgnitePoseTracker pose;

        private readonly IgniteStick thumb;

        private readonly IgniteTrigger indexFinger;

        private readonly IgniteTrigger handGrip;

        internal IgniteHandController(IHandController device)
        {
            pose = new IgnitePoseTracker(device.Pose);

            thumb = new IgniteStick(device.Thumb);

            indexFinger = new IgniteTrigger(device.IndexFinger);

            handGrip = new IgniteTrigger(device.HandGrip);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            pose.Connect(handler.Pose).Synthesize(synthesized);
            thumb.Connect(handler.Thumb).Synthesize(synthesized);
            indexFinger.Connect(handler.IndexFinger).Synthesize(synthesized);
            handGrip.Connect(handler.HandGrip).Synthesize(synthesized);

            return synthesized;
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
