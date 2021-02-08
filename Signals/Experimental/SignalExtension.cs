using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Translation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    public static class SignalExtension
    {
        #region Touch

        public static Touch ToTouch(this bool signal)
        {
            return signal ? Touch.Enabled : Touch.Disabled;
        }

        public static bool ToBoolean(this Touch signal)
        {
            return signal == Touch.Enabled;
        }

        #endregion

        #region Push

        public static Push ToPush(this bool signal)
        {
            return signal ? Push.Enabled : Push.Disabled;
        }

        public static bool ToBoolean(this Push signal)
        {
            return signal == Push.Enabled;
        }

        #endregion

        #region Pull

        public static Pull ToPull(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Pull(signal);
        }

        public static float ToSingle(this Pull signal)
        {
            return signal.Strength;
        }

        public static IConnection<Push> Convert(this IConnection<Pull> connection, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Convert(new PullToPush(threshold, isPushed));
        }

        #endregion

        #region Pupil

        public static Pupil ToPupil(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Pupil(signal);
        }

        public static float ToSingle(this Pupil signal)
        {
            return signal.Ratio;
        }

        public static IConnection<Push> Convert(this IConnection<Pupil> connection, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Convert(new PupilToPush(threshold, isPushed));
        }

        #endregion

        #region Blink

        public static Blink ToBlink(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Blink(signal);
        }

        public static float ToSingle(this Blink signal)
        {
            return signal.Ratio;
        }

        public static IConnection<Push> Convert(this IConnection<Blink> connection, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Convert(new BlinkToPush(threshold, isPushed));
        }

        #endregion

        #region Angle

        public static Angle ToAngle(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = -180.0f;
            const float Max = 180.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Angle(signal);
        }

        public static float ToSingle(this Angle signal)
        {
            return signal.Degree;
        }

        #endregion

        #region Position

        public static IConnection<Position> Calibrate(this IConnection<Position> connection, ICalibration<Position> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(Signals.Calibrate.Position, calibration);
        }

        #endregion

        #region Rotation

        public static IConnection<Rotation> Calibrate(this IConnection<Rotation> connection, ICalibration<Rotation> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(Signals.Calibrate.Rotation, calibration);
        }

        #endregion

        #region Direction

        public static IConnection<Direction> Calibrate(this IConnection<Direction> connection, ICalibration<Direction> calibration)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return connection.Calibrate(Signals.Calibrate.Direction, calibration);
        }

        #endregion
    }
}
