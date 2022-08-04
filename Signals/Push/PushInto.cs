using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public static class PushInto
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Touch"/>.
        /// </summary>
        public sealed class TouchWhen :
            ITranslation<Push, Touch>
        {
            /// <summary>
            /// Converts <see cref="Push.Enabled"/> into <see cref="Touch.Enabled"/> and <see cref="Push.Disabled"/> into <see cref="Touch.Disabled"/>.
            /// </summary>
            public static ITranslation<Push, Touch> Enabled { get; } = new TouchWhen(signal => (Touch)signal);

            /// <summary>
            /// Converts <see cref="Push.Disabled"/> into <see cref="Touch.Enabled"/> and <see cref="Push.Enabled"/> into <see cref="Touch.Disabled"/>.
            /// </summary>
            public static ITranslation<Push, Touch> Disabled { get; } = new TouchWhen(signal => (Touch)(-signal));

            private readonly Func<Push, Touch> onTranslated;

            private TouchWhen(Func<Push, Touch> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Touch Translate(Push signal)
            {
                return onTranslated.Invoke(signal);
            }
        }

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Pull"/>.
        /// </summary>
        public sealed class PullWhen :
            ITranslation<Push, Pull>
        {
            /// <summary>
            /// Converts <see cref="Push.Enabled"/> into <see cref="Pull.Pulled"/> and <see cref="Push.Disabled"/> into <see cref="Pull.Released"/>.
            /// </summary>
            public static ITranslation<Push, Pull> Enabled { get; } = new PullWhen(signal => (Pull)signal);

            /// <summary>
            /// Converts <see cref="Push.Disabled"/> into <see cref="Pull.Pulled"/> and <see cref="Push.Enabled"/> into <see cref="Pull.Released"/>.
            /// </summary>
            public static ITranslation<Push, Pull> Disabled { get; } = new PullWhen(signal => (Pull)(-signal));

            private readonly Func<Push, Pull> onTranslated;

            private PullWhen(Func<Push, Pull> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Pull Translate(Push signal)
            {
                return onTranslated.Invoke(signal);
            }
        }
    }
}
