using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventInputSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IThreePointTrackerEventOutputHandler,
        IDisconnection
    {
        private readonly HeadsetEventInputSystem head;

        private readonly HandControllerEventInputSystem leftHand;
        
        private readonly HandControllerEventInputSystem rightHand;

        public ThreePointTrackerEventInputSystem(IThreePointTrackerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            head = new HeadsetEventInputSystem(threshold.Head);

            leftHand = new HandControllerEventInputSystem(threshold.LeftHand);

            rightHand = new HandControllerEventInputSystem(threshold.RightHand);
        }

        #region IThreePointTrackerEventHandler

        public IHeadsetEventOutputHandler Head => head;

        public IHandControllerEventOutputHandler LeftHand => leftHand;

        public IHandControllerEventOutputHandler RightHand => rightHand;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IThreePointTrackerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var head = this.head.Connect(handler.Head);

            var leftHand = this.leftHand.Connect(handler.LeftHand);

            var rightHand = this.rightHand.Connect(handler.RightHand);

            return new Disconnection(() =>
            {
                head.Disconnect();

                leftHand.Disconnect();

                rightHand.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            head.Disconnect();

            leftHand.Disconnect();

            rightHand.Disconnect();
        }

        #endregion
    }
}
