using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Button"/>.
    /// </summary>
    public static class FromButton
    {
        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Touch"/>.
        /// </summary>
        public static ITranslation<Button, Touch> IntoTouch { get; } = new FromButtonIntoTouch();
        private sealed class FromButtonIntoTouch :
            ITranslation<Button, Touch>
        {
            public Touch Translate(Button signal)
            {
                return signal.Touch;
            }
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Push"/>.
        /// </summary>
        public static ITranslation<Button, Push> IntoPush { get; } = new FromButtonIntoPush();
        private sealed class FromButtonIntoPush :
            ITranslation<Button, Push>
        {
            public Push Translate(Button signal)
            {
                return signal.Push;
            }
        }

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Trigger"/>.
        /// </summary>
        public static ITranslation<Button, Trigger> IntoTrigger { get; } = new FromButtonIntoTrigger();
        private sealed class FromButtonIntoTrigger :
            ITranslation<Button, Trigger>
        {
            public Trigger Translate(Button signal)
            {
                return (Trigger)signal;
            }
        }
    }
}
