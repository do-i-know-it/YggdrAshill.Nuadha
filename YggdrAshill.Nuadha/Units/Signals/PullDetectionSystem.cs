using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullDetectionSystem :
        IHardware<IDetectionHardwareHandler>
    {
        private readonly PushDetectionSystem detection;

        public PullDetectionSystem(IConnection<Pull> connection, HysteresisThreshold threshold)
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

            detection = new PushDetectionSystem(connection.Translate(translation));
        }

        public IDisconnection Connect(IDetectionHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return detection.Connect(handler);
        }
    }
}
