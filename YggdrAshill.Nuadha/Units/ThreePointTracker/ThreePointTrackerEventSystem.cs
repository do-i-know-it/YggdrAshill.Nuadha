using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventSystem :
        IThreePointTrackerEventSystem
    {
        private readonly IHandControllerEventSystem leftHand;
        
        private readonly IHandControllerEventSystem rightHand;

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
