using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerThreshold :
        IThreePointTrackerThreshold
    {
        public IHeadsetThreshold Head { get; }

        public IHandControllerThreshold LeftHand { get; }

        public IHandControllerThreshold RightHand { get; }

        #region Constructor

        public ThreePointTrackerThreshold(
            HysteresisThreshold pupil,
            HysteresisThreshold blink, 
            HysteresisThreshold thumbStick, 
            HysteresisThreshold fingerTrigger,
            HysteresisThreshold handTrigger)
        {
            if (pupil == null)
            {
                throw new ArgumentNullException(nameof(pupil));
            }
            if (blink == null)
            {
                throw new ArgumentNullException(nameof(blink));
            }
            if (thumbStick == null)
            {
                throw new ArgumentNullException(nameof(thumbStick));
            }
            if (fingerTrigger == null)
            {
                throw new ArgumentNullException(nameof(fingerTrigger));
            }
            if (handTrigger == null)
            {
                throw new ArgumentNullException(nameof(handTrigger));
            }

            Head = new HeadsetThreshold(pupil, blink);

            LeftHand = new HandControllerThreshold(thumbStick, fingerTrigger, handTrigger);

            RightHand = new HandControllerThreshold(thumbStick, fingerTrigger, handTrigger);
        }

        public ThreePointTrackerThreshold(
            IHeadsetThreshold head, 
            IHandControllerThreshold leftHand, 
            IHandControllerThreshold rightHand)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }
            if (leftHand == null)
            {
                throw new ArgumentNullException(nameof(leftHand));
            }
            if (rightHand == null)
            {
                throw new ArgumentNullException(nameof(rightHand));
            }

            Head = head;
            
            LeftHand = leftHand;
            
            RightHand = rightHand;
        }

        #endregion
    }
}
