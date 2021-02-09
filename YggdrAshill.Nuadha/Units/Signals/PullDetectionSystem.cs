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
        private readonly PullTranslationSystem translation;

        private readonly PushDetectionSystem detection = new PushDetectionSystem();

        public PullDetectionSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            translation = new PullTranslationSystem(threshold);
        }

        #region IConsumption

        public void Consume(Pull signal)
        {
            translation.Consume(signal);
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
            translation.Disconnect();

            detection.Disconnect();
        }

        #endregion
    }
}
