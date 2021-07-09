using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IHandControllerThreshold
    {
        ITiltThreshold Thumb { get; }

        HysteresisThreshold IndexFinger { get; }

        HysteresisThreshold HandGrip { get; }
    }
}
