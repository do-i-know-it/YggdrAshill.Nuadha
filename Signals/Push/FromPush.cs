using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public static class FromPush
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Touch"/>.
        /// </summary>
        public static IConversion<Push, Touch> IntoTouch { get; } = From<Push>.Into<Touch>.Like(signal => (Touch)signal);

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Pull"/>.
        /// </summary>
        public static IConversion<Push, Pull> IntoPull { get; } = From<Push>.Into<Pull>.Like(signal => (Pull)signal);
    }
}
