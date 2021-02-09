using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCalibrationSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IHardware<IThreePointTrackerCalibrationInputHandler>,
        IDisconnection
    {
        private readonly PoseTrackerCalibrationSystem head;
        
        private readonly PoseTrackerCalibrationSystem leftHand;
        
        private readonly PoseTrackerCalibrationSystem rightHand;

        public ThreePointTrackerCalibrationSystem(IThreePointTrackerCalibration calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            head = new PoseTrackerCalibrationSystem(calibration.Head);

            leftHand = new PoseTrackerCalibrationSystem(calibration.LeftHand);

            rightHand = new PoseTrackerCalibrationSystem(calibration.RightHand);
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
