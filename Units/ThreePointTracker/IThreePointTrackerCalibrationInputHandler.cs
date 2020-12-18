using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerCalibrationInputHandler :
       IHardwareHandler
    {
        IPoseTrackerHardwareHandler Head { get; }

        IPoseTrackerHardwareHandler LeftHand { get; }

        IPoseTrackerHardwareHandler RightHand { get; }
    }
}
