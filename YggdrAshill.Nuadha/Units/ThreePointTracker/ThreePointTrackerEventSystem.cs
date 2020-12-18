using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IDisconnection
    {
        private readonly HeadsetEventSystem head;

        private readonly HandControllerEventSystem leftHand;
        
        private readonly HandControllerEventSystem rightHand;

        public ThreePointTrackerEventSystem(IThreePointTrackerThreshold threshold, IThreePointTrackerEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            head = new HeadsetEventSystem(threshold.Head, handler.Head);

            leftHand = new HandControllerEventSystem(threshold.LeftHand, handler.LeftHand);

            rightHand = new HandControllerEventSystem(threshold.RightHand, handler.RightHand);
        }

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
