using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Stick"/>.
    /// </summary>
    public sealed class StickInto :
        ITranslation<Stick, Touch>,
        ITranslation<Stick, Push>,
        ITranslation<Stick, Tilt>
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Stick, Touch> Touch => instance;

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Push"/>.
        /// </summary>
        public static ITranslation<Stick, Push> Push => instance;

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="Signals.Tilt"/>.
        /// </summary>
        public static ITranslation<Stick, Tilt> Tilt => instance;

        private static readonly StickInto instance = new StickInto();

        private StickInto()
        {

        }

        Touch ITranslation<Stick, Touch>.Translate(Stick signal)
        {
            return signal.Touch;
        }

        Push ITranslation<Stick, Push>.Translate(Stick signal)
        {
            return signal.Push;
        }

        Tilt ITranslation<Stick, Tilt>.Translate(Stick signal)
        {
            return signal.Tilt;
        }
    }
}
