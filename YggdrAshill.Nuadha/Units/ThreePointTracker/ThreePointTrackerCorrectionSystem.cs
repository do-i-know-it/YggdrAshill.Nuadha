using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCorrectionSystem :
        IHardware<IThreePointTrackerHardwareHandler>
    {
        private readonly PoseTrackerCorrectionSystem head;

        private readonly PoseTrackerCorrectionSystem leftHand;
        
        private readonly PoseTrackerCorrectionSystem rightHand;

        public ThreePointTrackerCorrectionSystem(
            IThreePointTrackerSoftwareHandler handler, 
            IPoseTrackerCalculation calculation, 
            IThreePointTrackerConfiguration configuration)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            head = new PoseTrackerCorrectionSystem(handler.Head, calculation, configuration.Head);

            leftHand = new PoseTrackerCorrectionSystem(handler.LeftHand, calculation, configuration.LeftHand);
            
            rightHand = new PoseTrackerCorrectionSystem(handler.RightHand, calculation, configuration.RightHand);
        }

        public IDisconnection Connect(IThreePointTrackerHardwareHandler handler)
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
    }
}
