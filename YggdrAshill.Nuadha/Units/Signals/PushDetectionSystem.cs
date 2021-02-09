using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class PushDetectionSystem : DetectionSystem<Push>
    {
        protected override IPropagation<Push> Propagation { get; } = new Propagation<Push>();

        protected override IDetection<Push> HasEnabled { get; } = PushToPulse.HasEnabled();

        protected override IDetection<Push> IsEnabled { get; } = PushToPulse.IsEnabled();

        protected override IDetection<Push> HasDisabled { get; } = PushToPulse.HasDisabled();

        protected override IDetection<Push> IsDisabled { get; } = PushToPulse.IsDisabled();
    }
}
