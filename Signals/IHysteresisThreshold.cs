namespace YggdrAshill.Nuadha.Signals
{
    public interface IHysteresisThreshold
    {
        float LowerLimit { get; }

        float UpperLimit { get; }
    }
}
