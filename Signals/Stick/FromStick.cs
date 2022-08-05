using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Stick"/>.
    /// </summary>
    public static class FromStick
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Touch"/>.
        /// </summary>
        public static ITranslation<Stick, Touch> IntoTouch { get; } = new FromStickIntoTouch();
        private sealed class FromStickIntoTouch :
            ITranslation<Stick, Touch>
        {
            public Touch Translate(Stick signal)
            {
                return signal.Touch;
            }
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Push"/>.
        /// </summary>
        public static ITranslation<Stick, Push> IntoPush { get; } = new FromStickIntoPush();
        private sealed class FromStickIntoPush :
            ITranslation<Stick, Push>
        {
            public Push Translate(Stick signal)
            {
                return signal.Push;
            }
        }

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Tilt"/>.
        /// </summary>
        public static ITranslation<Stick, Tilt> IntoTilt { get; } = new FromStickIntoTilt();
        private sealed class FromStickIntoTilt :
            ITranslation<Stick, Tilt>
        {
            public Tilt Translate(Stick signal)
            {
                return signal.Tilt;
            }
        }
    }
}
