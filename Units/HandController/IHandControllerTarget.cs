using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerTarget
    {
        ITarget<Battery> Battery { get; }

        ITarget<Tilt> Thumb { get; }

        ITarget<Pull> IndexFinger { get; }

        ITarget<Pull> HandGrip { get; }
    }
}
