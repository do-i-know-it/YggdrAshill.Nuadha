using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCorrectionDevice :
        IHardware<IThreePointTrackerSystem>
    {
        private readonly PoseTrackerCorrectionDevice head;

        private readonly PoseTrackerCorrectionDevice leftHand;
        
        private readonly PoseTrackerCorrectionDevice rightHand;

        public ThreePointTrackerCorrectionDevice(
            IThreePointTrackerDevice device, 
            IPoseTrackerCalculation calculation, 
            IThreePointTrackerConfiguration configuration)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            head = new PoseTrackerCorrectionDevice(device.Head, calculation, configuration.Head);

            leftHand = new PoseTrackerCorrectionDevice(device.LeftHand, calculation, configuration.LeftHand);
            
            rightHand = new PoseTrackerCorrectionDevice(device.RightHand, calculation, configuration.RightHand);
        }

        public IDisconnection Connect(IThreePointTrackerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var head = this.head.Connect(system.Head);

            var leftHand = this.leftHand.Connect(system.LeftHand);
            
            var rightHand = this.rightHand.Connect(system.RightHand);

            return new Disconnection(() =>
            {
                head.Disconnect();

                leftHand.Disconnect();

                rightHand.Disconnect();
            });
        }
    }
}
