using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class RotationToRotation
    {
        #region Addition

        public static IReduction<Rotation> Add { get; }
            = new Reduction<Rotation>((left, right) =>
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
            });

        #endregion

        #region Subtraction

        public static IReduction<Rotation> Subtract { get; }
            = new Reduction<Rotation>((left, right) =>
            {
                return Add.Reduce(left, right.Inversed);
            });

        #endregion

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
    }
}
