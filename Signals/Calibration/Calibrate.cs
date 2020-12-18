using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class Calibrate :
        IReduction<Position>,
        IReduction<Rotation>,
        IReduction<Direction>,
        IReduction<Angle>
    {
        #region Singleton

        private static Calibrate Instance { get; } = new Calibrate();

        private Calibrate()
        {

        }

        #endregion

        #region Position

        public static IReduction<Position> Position => Instance;
        
        public Position Reduce(Position left, Position right)
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

        public static IReduction<Rotation> Rotation => Instance;

        public Rotation Reduce(Rotation left, Rotation right)
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

        public static IReduction<Direction> Direction => Instance;

        public Direction Reduce(Direction left, Direction right)
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

        public static IReduction<Angle> Angle => Instance;

        public Angle Reduce(Angle left, Angle right)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
