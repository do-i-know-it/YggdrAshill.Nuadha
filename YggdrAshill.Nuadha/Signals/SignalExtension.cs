using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Signals.
    /// </summary>
    public static class SignalExtension
    {
        #region Touch

        /// <summary>
        /// Converts <see cref="bool"/> to <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> converted.
        /// </returns>
        public static Touch ToTouch(this bool signal)
        {
            return (Touch)signal;
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool ToBoolean(this Touch signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="Push"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Push"/> converted.
        /// </returns>
        public static Push ToPush(this Touch signal)
        {
            return signal.ToBoolean().ToPush();
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static Pull ToPull(this Touch signal)
        {
            return signal ? Pull.Maximum.ToPull() : Pull.Minimum.ToPull();
        }

        #endregion

        #region Push

        /// <summary>
        /// Converts <see cref="bool"/> to <see cref="Push"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Push"/> converted.
        /// </returns>
        public static Push ToPush(this bool signal)
        {
            return (Push)signal;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool ToBoolean(this Push signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> converted.
        /// </returns>
        public static Touch ToTouch(this Push signal)
        {
            return signal.ToBoolean().ToTouch();
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static Pull ToPull(this Push signal)
        {
            return signal ? Pull.Maximum.ToPull() : Pull.Minimum.ToPull();

        }

        #endregion

        #region Pull

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static Pull ToPull(this float signal)
        {
            if (signal < Pull.Minimum)
            {
                signal = Pull.Minimum;
            }
            if (signal > Pull.Maximum)
            {
                signal = Pull.Maximum;
            }

            return (Pull)signal;
        }

        /// <summary>
        /// Converts <see cref="Pull"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Pull"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(this Pull signal)
        {
            return (float)signal;
        }

        #endregion

        #region Angle

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Angle.Radian"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Radian"/> converted.
        /// </returns>
        public static Angle.Radian ToRadian(this float signal)
        {
            if (signal < Angle.Radian.Minimum)
            {
                signal = Angle.Radian.Minimum;
            }
            if (signal > Angle.Radian.Maximum)
            {
                signal = Angle.Radian.Maximum;
            }

            return (Angle.Radian)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Radian"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Radian"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(this Angle.Radian signal)
        {
            return (float)signal;
        }

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Angle.Degree"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Degree"/> converted.
        /// </returns>
        public static Angle.Degree ToDegree(float signal)
        {
            if (signal < Angle.Degree.Minimum)
            {
                signal = Angle.Degree.Minimum;
            }
            if (signal > Angle.Degree.Maximum)
            {
                signal = Angle.Degree.Maximum;
            }

            return (Angle.Degree)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Degree"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Degree"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(Angle.Degree signal)
        {
            return (float)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Degree"/> to <see cref="Angle.Radian"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Degree"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Radian"/> converted.
        /// </returns>
        public static Angle.Radian ToRadian(this Angle.Degree signal)
        {
            return (Angle.Radian)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Radian"/> to <see cref="Angle.Degree"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Radian"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Degree"/> converted.
        /// </returns>
        public static Angle.Degree ToDegree(Angle.Radian signal)
        {
            return (Angle.Degree)signal;
        }

        #endregion

        #region Battery

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Battery"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Battery"/> converted.
        /// </returns>
        public static Battery ToBattery(this float signal)
        {
            if (signal < Battery.Empty)
            {
                signal = Battery.Empty;
            }
            if (signal > Battery.Full)
            {
                signal = Battery.Full;
            }

            return (Battery)signal;
        }

        /// <summary>
        /// Converts <see cref="Battery"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Battery"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(this Battery signal)
        {
            return (float)signal;
        }

        #endregion
    }
}
