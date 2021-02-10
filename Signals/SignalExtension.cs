using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Signals
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

        public static IConnection<Push> Translate(this IConnection<Pull> connection, HysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Translate(new PullToPush(threshold, isPushed));
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

        public static IConnection<Push> Translate(this IConnection<Pupil> connection, HysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Translate(new PupilToPush(threshold, isPushed));
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

        public static IConnection<Push> Translate(this IConnection<Blink> connection, HysteresisThreshold threshold, bool isPushed = false)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return connection.Translate(new BlinkToPush(threshold, isPushed));
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

        public static IConnection<Position> Correct(this IConnection<Position> connection, IGeneration<Position> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(Calculation.Position, generation);
        }

        #endregion

        #region Rotation

        public static IConnection<Rotation> Correct(this IConnection<Rotation> connection, IGeneration<Rotation> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(Calculation.Rotation, generation);
        }

        #endregion

        #region Direction

        public static IConnection<Direction> Correct(this IConnection<Direction> connection, IGeneration<Direction> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(Calculation.Direction, generation);
        }

        #endregion
    }
}
