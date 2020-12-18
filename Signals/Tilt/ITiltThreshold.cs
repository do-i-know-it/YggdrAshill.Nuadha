namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltThreshold
    {
        IHysteresisThreshold Left { get; }

        IHysteresisThreshold Right { get; }

        IHysteresisThreshold Forward { get; }

        IHysteresisThreshold Backward { get; }
    }
}
