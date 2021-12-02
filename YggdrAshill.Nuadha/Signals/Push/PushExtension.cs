using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Push"/>.
    /// </summary>
    public static class PushExtension
    {
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
    }
}
