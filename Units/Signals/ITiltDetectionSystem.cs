using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionSystem :
        ISystem
    {
        IDetectionSystem Left { get; }

        IDetectionSystem Right { get; }

        IDetectionSystem Forward { get; }

        IDetectionSystem Backward { get; }
    }
}
