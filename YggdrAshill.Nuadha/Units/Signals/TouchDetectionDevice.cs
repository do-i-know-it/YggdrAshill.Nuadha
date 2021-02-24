using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TouchDetectionDevice : DetectionDevice<Touch>
    {
        public TouchDetectionDevice(IConnection<Touch> connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            Connection = connection;
        }

        protected override IConnection<Touch> Connection { get; }

        protected override IDetection<Touch> HasEnabled { get; } = TouchToPulse.HasEnabled();

        protected override IDetection<Touch> IsEnabled { get; } = TouchToPulse.IsEnabled();

        protected override IDetection<Touch> HasDisabled { get; } = TouchToPulse.HasDisabled();

        protected override IDetection<Touch> IsDisabled { get; } = TouchToPulse.IsDisabled();
    }
}
