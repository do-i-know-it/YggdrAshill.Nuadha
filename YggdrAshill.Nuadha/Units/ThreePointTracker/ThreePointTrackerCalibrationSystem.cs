using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCalibrationSystem :
        ISoftware<IThreePointTrackerSoftwareHandler>,
        IDisconnection
    {
        private readonly PoseTrackerCalibrationSystem head;
        
        private readonly PoseTrackerCalibrationSystem leftHand;
        
        private readonly PoseTrackerCalibrationSystem rightHand;

        public ThreePointTrackerCalibrationSystem(IThreePointTrackerCalibration calibration, IThreePointTrackerCalibrationInputHandler handler)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            head = new PoseTrackerCalibrationSystem(calibration.Head, handler.Head);

            leftHand = new PoseTrackerCalibrationSystem(calibration.LeftHand, handler.LeftHand);

            rightHand = new PoseTrackerCalibrationSystem(calibration.RightHand, handler.RightHand);
        }

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

        public void Disconnect()
        {
            head.Disconnect();

            leftHand.Disconnect();

            rightHand.Disconnect();
        }
    }
}
