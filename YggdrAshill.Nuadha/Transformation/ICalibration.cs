using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public interface ICalibration<TSignal>
        where TSignal : ISignal
    {
        TSignal Calibrate(TSignal signal, TSignal offset);
    }
}
