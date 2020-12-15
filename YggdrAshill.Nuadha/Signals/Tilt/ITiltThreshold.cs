namespace YggdrAshill.Nuadha
{
    public interface ITiltThreshold
    {
        HysteresisThreshold Center { get; }

        HysteresisThreshold Left { get; }

        HysteresisThreshold Right { get; }

        HysteresisThreshold Up { get; }

        HysteresisThreshold Down { get; }
    }
}
