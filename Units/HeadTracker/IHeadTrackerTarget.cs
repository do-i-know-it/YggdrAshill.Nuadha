using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Monitorization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerTarget
    {
        ITarget<Battery> Battery { get; }
    }
}
