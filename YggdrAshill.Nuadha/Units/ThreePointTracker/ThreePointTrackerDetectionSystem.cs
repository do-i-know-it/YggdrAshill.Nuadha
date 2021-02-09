using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerDetectionSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IHardware<IThreePointTrackerDetectionInputHandler>,
        IDisconnection
    {
        private readonly HandControllerDetectionSystem leftHand;
        
        private readonly HandControllerDetectionSystem rightHand;

        public ThreePointTrackerDetectionSystem(IThreePointTrackerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            leftHand = new HandControllerDetectionSystem(threshold.LeftHand);

            rightHand = new HandControllerDetectionSystem(threshold.RightHand);
        }

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

        #region IHardware

        public IDisconnection Connect(IThreePointTrackerDetectionInputHandler handler)
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
