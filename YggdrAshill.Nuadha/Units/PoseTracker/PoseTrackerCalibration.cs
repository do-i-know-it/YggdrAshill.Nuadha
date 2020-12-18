using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCalibration :
        IPoseTrackerCalibration
    {
        public ICalibration<Position> Position { get; }

        public ICalibration<Rotation> Rotation { get; }

        #region Constructor

        public PoseTrackerCalibration(Func<Position> position, Func<Rotation> rotation)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            if (rotation == null)
            {
                throw new ArgumentNullException(nameof(rotation));
            }

            Position = new Calibration<Position>(position);

            Rotation = new Calibration<Rotation>(rotation);
        }

        public PoseTrackerCalibration(Position position, Rotation rotation)
        {
            Position = new Calibration<Position>(position);

            Rotation = new Calibration<Rotation>(rotation);
        }

        #endregion
    }
}
