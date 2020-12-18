using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
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

        public static IOutputTerminal<Push> Convert(this IOutputTerminal<Pull> terminal, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return terminal.Convert(new PullToPush(threshold, isPushed));
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

        public static IOutputTerminal<Push> Convert(this IOutputTerminal<Pupil> terminal, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return terminal.Convert(new PupilToPush(threshold, isPushed));
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

        public static IOutputTerminal<Push> Convert(this IOutputTerminal<Blink> terminal, IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return terminal.Convert(new BlinkToPush(threshold, isPushed));
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

        public static IOutputTerminal<Position> Calibrate(this IOutputTerminal<Position> terminal, ICalibration<Position> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Position, calibration);
        }

        #endregion

        #region Rotation

        public static IOutputTerminal<Rotation> Calibrate(this IOutputTerminal<Rotation> terminal, ICalibration<Rotation> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Rotation, calibration);
        }

        #endregion

        #region Direction

        public static IOutputTerminal<Direction> Calibrate(this IOutputTerminal<Direction> terminal, ICalibration<Direction> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Direction, calibration);
        }

        #endregion
    }
}
