using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Pull"/>.
    /// </summary>
    public static class PullExtension
    {
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
    }
}
