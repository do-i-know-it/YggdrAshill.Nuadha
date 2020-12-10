using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetEventHandler :
        ISoftwareHandler
    {
        IEyeTrackerEventHandler LeftEye { get; }

        IEyeTrackerEventHandler RightEye { get; }
    }
}
