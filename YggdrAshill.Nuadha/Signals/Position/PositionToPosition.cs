using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class PositionToPosition
    {
        #region Addition

        public static IReduction<Position> Add { get; }
            = new Reduction<Position>((left, right) =>
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
            });

        #endregion

        #region Subtraction

        public static IReduction<Position> Subtract { get; } 
            = new Reduction<Position>((left, right) =>
            {
                return Add.Reduce(left, right.Inversed);
            });

        #endregion
    }
}
