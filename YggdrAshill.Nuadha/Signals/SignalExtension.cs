using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Signals.
    /// </summary>
    public static class SignalExtension
    {
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
            if (signal < Battery.Minimum)
            {
                signal = Battery.Minimum;
            }
            if (signal > Battery.Maximum)
            {
                signal = Battery.Maximum;
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
