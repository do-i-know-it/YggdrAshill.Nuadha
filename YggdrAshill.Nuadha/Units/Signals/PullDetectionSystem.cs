using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullDetectionSystem :
        IConsumption<Pull>,
        IHardware<IPulseDetectionInputHandler>,
        IDisconnection
    {
        private readonly PullConversionSystem conversion;

        private readonly PushDetectionSystem detection = new PushDetectionSystem();

        public PullDetectionSystem(IHysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            conversion = new PullConversionSystem(threshold);
        }

        #region IConsumption

        public void Consume(Pull signal)
        {
            conversion.Consume(signal);
        }

        #endregion

        #region IHardware

        public IDisconnection Connect(IPulseDetectionInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return detection.Connect(handler);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            conversion.Disconnect();

            detection.Disconnect();
        }

        #endregion
    }
}
