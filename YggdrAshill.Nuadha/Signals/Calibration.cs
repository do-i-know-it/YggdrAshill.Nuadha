using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class Calibration
    {
        public static ICorrection<Position> Position(Func<Position> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return new Correction<Position>(signal =>
            {
                var offset = calibration.Invoke();

                var horizontal
                    = signal.Horizontal
                    + offset.Horizontal;

                var vertical
                    = signal.Vertical
                    + offset.Vertical;

                var frontal
                    = signal.Frontal
                    + offset.Frontal;

                return new Position(horizontal, vertical, frontal);
            });
        }

        public static ICorrection<Rotation> Rotation(Func<Rotation> calibration)
        {
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return new Correction<Rotation>(signal =>
            {
                var offset = calibration.Invoke();

                var leftW = signal.Angle;
                var leftX = signal.Horizontal;
                var leftY = signal.Vertical;
                var leftZ = signal.Frontal;

                var rightW = offset.Angle;
                var rightX = offset.Horizontal;
                var rightY = offset.Vertical;
                var rightZ = offset.Frontal;

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
    }
}
