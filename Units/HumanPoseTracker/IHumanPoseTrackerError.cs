using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHumanPoseTrackerError
    {
        IError<Space3D.Pose> Head { get; }

        IError<Space3D.Pose> LeftHand { get; }

        IError<Space3D.Pose> RightHand { get; }
    }
}
