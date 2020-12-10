using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IThreePointTrackerEventHandler,
        IDisconnection
    {
        private readonly HandControllerEventSystem leftHand;
        
        private readonly HandControllerEventSystem rightHand;

        public ThreePointTrackerEventSystem(HysteresisThreshold thumbStick, HysteresisThreshold fingerTrigger, HysteresisThreshold handTrigger)
        {
            leftHand = new HandControllerEventSystem(thumbStick, fingerTrigger, handTrigger);

            rightHand = new HandControllerEventSystem(thumbStick, fingerTrigger, handTrigger);
        }

        #region IThreePointTrackerEventHandler

        public IHandControllerEventHandler LeftHand => leftHand;

        public IHandControllerEventHandler RightHand => rightHand;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IThreePointTrackerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var leftHand = this.leftHand.Connect(handler.LeftHand);

            var rightHand = this.rightHand.Connect(handler.RightHand);

            return new Disconnection(() =>
            {
                leftHand.Disconnect();

                rightHand.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            leftHand.Disconnect();

            rightHand.Disconnect();
        }

        #endregion
    }
}
