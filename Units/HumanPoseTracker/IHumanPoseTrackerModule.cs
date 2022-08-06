using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHumanPoseTrackerHardware"/> and <see cref="IHumanPoseTrackerSoftware"/>.
    /// </summary>
    public interface IHumanPoseTrackerModule :
        IModule<IHumanPoseTrackerHardware, IHumanPoseTrackerSoftware>
    {
        
    }
}
