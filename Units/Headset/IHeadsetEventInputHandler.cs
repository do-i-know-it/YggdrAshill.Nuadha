using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetEventInputHandler :
        IHardwareHandler
    {
        IEyeTrackerEventInputHandler LeftEye { get; }

        IEyeTrackerEventInputHandler RightEye { get; }
    }
}
