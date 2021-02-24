using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCorrectionDevice :
        IDevice<IThreePointTrackerSoftware>
    {
        private readonly PoseTrackerCorrectionDevice head;

        private readonly PoseTrackerCorrectionDevice leftHand;
        
        private readonly PoseTrackerCorrectionDevice rightHand;

        public ThreePointTrackerCorrectionDevice(
            IThreePointTrackerHardware hardware, 
            IPoseTrackerCalculation calculation, 
            IThreePointTrackerCalibration calibration)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            head = new PoseTrackerCorrectionDevice(hardware.Head, calculation, calibration.Head);

            leftHand = new PoseTrackerCorrectionDevice(hardware.LeftHand, calculation, calibration.LeftHand);
            
            rightHand = new PoseTrackerCorrectionDevice(hardware.RightHand, calculation, calibration.RightHand);
        }

        public IDisconnection Connect(IThreePointTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var head = this.head.Connect(software.Head);

            var leftHand = this.leftHand.Connect(software.LeftHand);
            
            var rightHand = this.rightHand.Connect(software.RightHand);

            return new Disconnection(() =>
            {
                head.Disconnect();

                leftHand.Disconnect();

                rightHand.Disconnect();
            });
        }
    }
}
