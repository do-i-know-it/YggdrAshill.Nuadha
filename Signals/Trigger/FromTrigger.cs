using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Trigger"/>.
    /// </summary>
    public static class FromTrigger
    {
        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Touch"/>.
        /// </summary>
        public static ITranslation<Trigger, Touch> IntoTouch { get; } = new FromTriggerIntoTouch();
        private sealed class FromTriggerIntoTouch :
            ITranslation<Trigger, Touch>
        {
            public Touch Translate(Trigger signal)
            {
                return signal.Touch;
            }
        }

        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Pull"/>.
        /// </summary>
        public static ITranslation<Trigger, Pull> IntoPull { get; } = new FromTriggerIntoPull();
        private sealed class FromTriggerIntoPull :
            ITranslation<Trigger, Pull>
        {
            public Pull Translate(Trigger signal)
            {
                return signal.Pull;
            }
        }
    }
}
