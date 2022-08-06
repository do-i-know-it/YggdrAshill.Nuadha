using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public interface IHandControllerModule :
        IModule<IHandControllerHardware, IHandControllerSoftware>
    {
        
    }
}
