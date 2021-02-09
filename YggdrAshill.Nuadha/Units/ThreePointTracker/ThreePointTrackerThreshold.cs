using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerThreshold :
        IThreePointTrackerThreshold
    {
        public IHandControllerThreshold LeftHand { get; }

        public IHandControllerThreshold RightHand { get; }

        #region Constructor

        public ThreePointTrackerThreshold(
            HysteresisThreshold thumbStick, 
            HysteresisThreshold fingerTrigger,
            HysteresisThreshold handTrigger)
        {
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

            LeftHand = new HandControllerThreshold(thumbStick, fingerTrigger, handTrigger);

            RightHand = new HandControllerThreshold(thumbStick, fingerTrigger, handTrigger);
        }

        public ThreePointTrackerThreshold(
            IHandControllerThreshold leftHand, 
            IHandControllerThreshold rightHand)
        {
            if (leftHand == null)
            {
                throw new ArgumentNullException(nameof(leftHand));
            }
            if (rightHand == null)
            {
                throw new ArgumentNullException(nameof(rightHand));
            }

            LeftHand = leftHand;
            
            RightHand = rightHand;
        }

        #endregion
    }
}
