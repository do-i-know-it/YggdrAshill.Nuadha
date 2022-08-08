using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerTarget
    {
        ITarget<Battery> Battery { get; }
    }
}
