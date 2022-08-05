using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Angle"/>.
    /// </summary>
    public static class AngleExtension
    {
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
    }
}
