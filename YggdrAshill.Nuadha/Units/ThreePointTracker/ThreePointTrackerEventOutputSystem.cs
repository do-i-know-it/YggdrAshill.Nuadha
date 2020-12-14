using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventOutputSystem :
        ISoftware<IThreePointTrackerEventOutputHandler>
    {
        private readonly HeadsetEventOutputSystem head;

        private readonly HandControllerEventOutputSystem leftHand;

        private readonly HandControllerEventOutputSystem rightHand;

        public ThreePointTrackerEventOutputSystem(IThreePointTrackerEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            head = new HeadsetEventOutputSystem(handler.Head);

            leftHand = new HandControllerEventOutputSystem(handler.LeftHand);
         
            rightHand = new HandControllerEventOutputSystem(handler.RightHand);
        }

        public IDisconnection Connect(IThreePointTrackerEventOutputHandler handler)
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
