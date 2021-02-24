namespace YggdrAshill.Nuadha
{
    public interface IThreePointTrackerCalibration
    {
        IPoseTrackerCalibration Origin { get; }

        IPoseTrackerCalibration Head { get; }

        IPoseTrackerCalibration LeftHand { get; }

        IPoseTrackerCalibration RightHand { get; }
    }
}
