using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public static class FromPush
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Touch"/>.
        /// </summary>
        public static ITranslation<Push, Touch> IntoTouch { get; } = new FromPushIntoTouch();
        private sealed class FromPushIntoTouch :
            ITranslation<Push, Touch>
        {
            public Touch Translate(Push signal)
            {
                return (Touch)signal;
            }
        }

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Push, Pull> IntoPull { get; } = new FromPushIntoPull();
        private sealed class FromPushIntoPull :
            ITranslation<Push, Pull>
        {
            public Pull Translate(Push signal)
            {
                return (Pull)signal;
            }
        }
    }
}
