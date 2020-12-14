using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetEventOutputSystem :
        ISoftware<IHeadsetEventOutputHandler>
    {
        private readonly EyeTrackerEventOutputSystem leftEye;
        
        private readonly EyeTrackerEventOutputSystem rightEye;

        public HeadsetEventOutputSystem(IHeadsetEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            leftEye = new EyeTrackerEventOutputSystem(handler.LeftEye);

            rightEye = new EyeTrackerEventOutputSystem(handler.RightEye);
        }

        public IDisconnection Connect(IHeadsetEventOutputHandler handler)
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
    }
}
