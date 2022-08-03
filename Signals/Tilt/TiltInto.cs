using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Tilt"/>.
    /// </summary>
    public static class TiltInto
    {
        /// <summary>
        /// Converts <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </summary>
        public sealed class PullBy :
            ITranslation<Tilt, Pull>
        {
            /// <summary>
            /// Converts <see cref="Tilt.Distance"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Distance { get; } = new PullBy(signal => signal.Distance);

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Left { get; } = new PullBy(signal => Math.Max(-signal.Horizontal, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Horizontal"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Right { get; } = new PullBy(signal => Math.Max(signal.Horizontal, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Forward { get; } = new PullBy(signal => Math.Max(signal.Vertical, 0));

            /// <summary>
            /// Converts <see cref="Tilt.Vertical"/> into <see cref="Pull"/>.
            /// </summary>
            public static ITranslation<Tilt, Pull> Backward { get; } = new PullBy(signal => Math.Max(-signal.Vertical, 0));

            private readonly Func<Tilt, float> onTranslated;

            private PullBy(Func<Tilt, float> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Pull Translate(Tilt signal)
            {
                return (Pull)onTranslated.Invoke(signal);
            }
        }
    }
}
