using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCalibration :
        IThreePointTrackerCalibration
    {
        public IPoseTrackerCalibration Head { get; }

        public IPoseTrackerCalibration LeftHand { get; }

        public IPoseTrackerCalibration RightHand { get; }

        public ThreePointTrackerCalibration(
            PoseTrackerCalibration head, 
            PoseTrackerCalibration leftHand, 
            PoseTrackerCalibration rightHand)
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
    }
}
