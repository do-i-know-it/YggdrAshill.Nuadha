using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Tilt"/>.
    /// </summary>
    public static class TiltInto
    {
        /// <summary>
        /// Converts <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </summary>
        public sealed class PullBy
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
            /// </summary>
            public static IConversion<Tilt, Pull> Distance { get; } = IntoPullFrom<Tilt>.Like(signal => signal.Distance);

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static IConversion<Tilt, Pull> Left { get; } = IntoPullFrom<Tilt>.Like(signal => Math.Max(-signal.Horizontal, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static IConversion<Tilt, Pull> Right { get; } = IntoPullFrom<Tilt>.Like(signal => Math.Max(signal.Horizontal, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static IConversion<Tilt, Pull> Forward { get; } = IntoPullFrom<Tilt>.Like(signal => Math.Max(signal.Vertical, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static IConversion<Tilt, Pull> Backward { get; } = IntoPullFrom<Tilt>.Like(signal => Math.Max(-signal.Vertical, 0));
        }
    }
}
