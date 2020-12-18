using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetEventSystem :
        ISoftware<IHeadsetSoftwareHandler>,
        IDisconnection
    {
        private readonly EyeTrackerEventSystem leftEye;

        private readonly EyeTrackerEventSystem rightEye;

        public HeadsetEventSystem(IHeadsetThreshold threshold, IHeadsetEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            leftEye = new  EyeTrackerEventSystem(threshold.LeftEye, handler.LeftEye);

            rightEye = new  EyeTrackerEventSystem(threshold.RightEye, handler.LeftEye);
        }

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
