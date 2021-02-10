using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCorrectionSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IHardware<IThreePointTrackerCalibrationInputHandler>,
        IDisconnection
    {
        private readonly PoseTrackerCorrectionSystem head;
        
        private readonly PoseTrackerCorrectionSystem leftHand;
        
        private readonly PoseTrackerCorrectionSystem rightHand;

        public ThreePointTrackerCorrectionSystem(IThreePointTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            head = new PoseTrackerCorrectionSystem(configuration.Head.PoseTracker);

            leftHand = new PoseTrackerCorrectionSystem(configuration.LeftHand.PoseTracker);

            rightHand = new PoseTrackerCorrectionSystem(configuration.RightHand.PoseTracker);
        }

        #region ISoftware

        public IDisconnection Connect(IThreePointTrackerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var head = this.head.Connect(handler.Head.PoseTracker);
            
            var leftHand = this.leftHand.Connect(handler.LeftHand.PoseTracker);
            
            var rightHand = this.rightHand.Connect(handler.RightHand.PoseTracker);

            return new Disconnection(() =>
            {
                head.Disconnect();

                leftHand.Disconnect();

                rightHand.Disconnect();
            });
        }

        #endregion

        #region IHardware

        public IDisconnection Connect(IThreePointTrackerCalibrationInputHandler handler)
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
