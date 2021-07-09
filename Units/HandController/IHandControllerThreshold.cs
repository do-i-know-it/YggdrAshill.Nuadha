using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerThreshold
    {
        ITiltThreshold Thumb { get; }

        HysteresisThreshold IndexFinger { get; }

        HysteresisThreshold HandGrip { get; }
    }
}
