using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetEventOutputHandler :
        ISoftwareHandler
    {
        IEyeTrackerEventOutputHandler LeftEye { get; }

        IEyeTrackerEventOutputHandler RightEye { get; }
    }
}
