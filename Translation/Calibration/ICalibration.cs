using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Conversion
{
    public interface ICalibration<TSignal>
        where TSignal : ISignal
    {
        TSignal Calibrate();
    }
}
