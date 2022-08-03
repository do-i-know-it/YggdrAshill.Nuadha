using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Touch"/>.
    /// </summary>
    public static class TouchExtension
    {
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
    }
}
