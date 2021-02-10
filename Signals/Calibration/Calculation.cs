using YggdrAshill.Nuadha.Conversion;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class Calculation :
        ICalculation<Position>,
        ICalculation<Rotation>,
        ICalculation<Direction>,
        ICalculation<Angle>
    {
        #region Singleton

        private static Calculation Instance { get; } = new Calculation();

        private Calculation()
        {

        }

        #endregion

        #region Position

        public static ICalculation<Position> Position { get; } = Instance;
        
        public Position Calculate(Position left, Position right)
        {
            var horizontal
                = left.Horizontal
                + right.Horizontal;

            var vertical
                = left.Vertical
                + right.Vertical;

            var frontal
                = left.Frontal
                + right.Frontal;

            return new Position(horizontal, vertical, frontal);
        }

        #endregion

        #region Rotation

        public static ICalculation<Rotation> Rotation { get; } = Instance;

        public Rotation Calculate(Rotation left, Rotation right)
        {
            var leftW = left.Angle;
            var leftX = left.Horizontal;
            var leftY = left.Vertical;
            var leftZ = left.Frontal;

            var rightW = right.Angle;
            var rightX = right.Horizontal;
            var rightY = right.Vertical;
            var rightZ = right.Frontal;

            var horizontal
                = (leftW * rightX)
                + (leftX * rightW)
                + (leftY * rightZ)
                - (leftZ * rightY);

            var vertical
                = (leftW * rightY)
                + (leftY * rightW)
                + (leftZ * rightX)
                - (leftX * rightZ);

            var frontal
                = (leftW * rightZ)
                + (leftZ * rightW)
                + (leftX * rightY)
                - (leftY * rightX);

            var angle
                = (leftW * rightW)
                - (leftX * rightX)
                - (leftY * rightY)
                - (leftZ * rightZ);

            horizontal = Clamp(horizontal);
            vertical = Clamp(vertical);
            frontal = Clamp(frontal);
            angle = Clamp(angle);

            return new Rotation(horizontal, vertical, frontal, angle);
        }
        private static float Clamp(float signal)
        {
            const float Min = -1.0f;
            const float Max = 1.0f;

            if (signal < Min)
            {
                return Min;
            }

            if (signal > Max)
            {
                return Max;
            }

            return signal;
        }

        #endregion

        #region Direction

        public static ICalculation<Direction> Direction { get; } = Instance;

        public Direction Calculate(Direction left, Direction right)
        {
            var horizontal
                = left.Horizontal
                + right.Horizontal;

            var vertical
                = left.Vertical
                + right.Vertical;

            var frontal
                = left.Frontal
                + right.Frontal;

            return new Direction(horizontal, vertical, frontal);
        }

        #endregion

        #region Angle

        public static ICalculation<Angle> Angle { get; } = Instance;

        public Angle Calculate(Angle left, Angle right)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
