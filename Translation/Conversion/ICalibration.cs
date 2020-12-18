using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    public interface ICalibration<TSignal>
        where TSignal : ISignal
    {
        TSignal Calibrate();
    }
}
