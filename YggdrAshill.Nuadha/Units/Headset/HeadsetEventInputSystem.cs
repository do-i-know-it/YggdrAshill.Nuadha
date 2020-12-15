using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetEventInputSystem :
        ISoftware<IHeadsetSoftwareHandler>,
        IHeadsetEventOutputHandler,
        IDisconnection
    {
        private readonly EyeTrackerEventInputSystem leftEye;

        private readonly EyeTrackerEventInputSystem rightEye;

        public HeadsetEventInputSystem(IHeadsetThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            leftEye = new  EyeTrackerEventInputSystem(threshold.LeftEye);

            rightEye = new  EyeTrackerEventInputSystem(threshold.RightEye);
        }

        #region IHeadsetEventOutputHandler

        public IEyeTrackerEventOutputHandler LeftEye => leftEye;

        public IEyeTrackerEventOutputHandler RightEye => rightEye;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IHeadsetSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var leftEye = this.leftEye.Connect(handler.LeftEye);

            var rightEye = this.rightEye.Connect(handler.RightEye);

            return new Disconnection(() =>
            {
                leftEye.Disconnect();

                rightEye.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            leftEye.Disconnect();

            rightEye.Disconnect();
        }

        #endregion
    }
}
