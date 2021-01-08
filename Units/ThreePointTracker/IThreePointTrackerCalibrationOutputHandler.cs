using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerCalibrationOutputHandler :
        ISoftwareHandler
    {
        IPoseTrackerSoftwareHandler Head { get; }

        IPoseTrackerSoftwareHandler LeftHand { get; }

        IPoseTrackerSoftwareHandler RightHand { get; }
    }
}
