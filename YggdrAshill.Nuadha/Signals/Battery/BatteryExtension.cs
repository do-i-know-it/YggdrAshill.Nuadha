using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Battery"/>.
    /// </summary>
    public static class BatteryExtension
    {
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
    }
}
