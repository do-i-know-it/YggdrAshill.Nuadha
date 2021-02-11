using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PushDetectionSystem : DetectionSystem<Push>
    {
        public PushDetectionSystem(IConnection<Push> connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            Connection = connection;
        }

        protected override IConnection<Push> Connection { get; }

        protected override IDetection<Push> HasEnabled { get; } = PushToPulse.HasEnabled();

        protected override IDetection<Push> IsEnabled { get; } = PushToPulse.IsEnabled();

        protected override IDetection<Push> HasDisabled { get; } = PushToPulse.HasDisabled();

        protected override IDetection<Push> IsDisabled { get; } = PushToPulse.IsDisabled();
    }
}
