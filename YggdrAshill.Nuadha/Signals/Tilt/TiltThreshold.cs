namespace YggdrAshill.Nuadha
{
    public sealed class TiltThreshold :
        ITiltThreshold
    {
        public HysteresisThreshold Center { get; }

        public HysteresisThreshold Left { get; }

        public HysteresisThreshold Right { get; }

        public HysteresisThreshold Forward { get; }

        public HysteresisThreshold Backward { get; }

        public TiltThreshold(HysteresisThreshold threshold)
        {
            Center = threshold;

            Left = threshold;

            Right = threshold;

            Forward = threshold;

            Backward = threshold;
        }
    }
}
