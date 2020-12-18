namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerCalibration
    {
        IPoseTrackerCalibration Head { get; }

        IPoseTrackerCalibration LeftHand { get; }
        
        IPoseTrackerCalibration RightHand { get; }
    }
}
