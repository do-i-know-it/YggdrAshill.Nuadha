using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IThreePointTrackerHardware"/> and <see cref="IThreePointTrackerSoftware"/>.
    /// </summary>
    public interface IThreePointTrackerModule :
        IModule<IThreePointTrackerHardware, IThreePointTrackerSoftware>
    {
        
    }
}
