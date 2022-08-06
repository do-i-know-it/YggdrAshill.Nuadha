using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public interface IHeadTrackerModule :
        IModule<IHeadTrackerHardware, IHeadTrackerSoftware>
    {
        
    }
}
