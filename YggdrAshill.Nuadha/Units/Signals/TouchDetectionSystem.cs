using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchDetectionSystem : DetectionSystem<Touch>
    {
        protected override IPropagation<Touch> Propagation { get; } = new Propagation<Touch>();

        protected override IDetection<Touch> HasEnabled { get; } = TouchToPulse.HasEnabled();

        protected override IDetection<Touch> IsEnabled { get; } = TouchToPulse.IsEnabled();

        protected override IDetection<Touch> HasDisabled { get; } = TouchToPulse.HasDisabled();

        protected override IDetection<Touch> IsDisabled { get; } = TouchToPulse.IsDisabled();
    }
}
