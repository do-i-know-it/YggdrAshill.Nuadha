using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetEventSystem :
        ISoftware<IHeadsetSoftwareHandler>,
        IHeadsetEventHandler,
        IDisconnection
    {
        private readonly EyeTrackerEventSystem leftEye;

        private readonly EyeTrackerEventSystem rightEye;

        public HeadsetEventSystem(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            leftEye = new  EyeTrackerEventSystem(pupil, blink);

            rightEye = new  EyeTrackerEventSystem(pupil, blink);
        }

        #region IHeadsetEventHandler

        public IEyeTrackerEventHandler LeftEye => leftEye;

        public IEyeTrackerEventHandler RightEye => rightEye;

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
