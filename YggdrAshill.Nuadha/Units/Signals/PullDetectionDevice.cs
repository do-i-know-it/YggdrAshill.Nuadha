using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullDetectionDevice :
        IDevice<IDetectionSoftware>
    {
        private readonly PushDetectionDevice detection;

        public PullDetectionDevice(IConnection<Pull> connection, HysteresisThreshold threshold)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            var translation = new PullToPush(threshold);

            detection = new PushDetectionDevice(connection.Translate(translation));
        }

        public IDisconnection Connect(IDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return detection.Connect(software);
        }
    }
}
