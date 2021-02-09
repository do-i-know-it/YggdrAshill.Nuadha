using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalExtension
    {
        #region Position

        public static IConnection<Position> Calibrate(this IConnection<Position> connection, Func<Position> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(new Calibration<Position>(calibration));
        }

        #endregion

        #region Rotation

        public static IConnection<Rotation> Calibrate(this IConnection<Rotation> connection, Func<Rotation> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(new Calibration<Rotation>(calibration));
        }

        #endregion

        #region Direction

        public static IConnection<Direction> Calibrate(this IConnection<Direction> connection, Func<Direction> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(new Calibration<Direction>(calibration));
        }

        #endregion
    }
}
