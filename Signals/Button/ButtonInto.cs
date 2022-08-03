using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Button"/>.
    /// </summary>
    public sealed class ButtonInto :
        ITranslation<Button, Touch>,
        ITranslation<Button, Push>
    {
        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Button, Touch> Touch => instance;

        /// <summary>
        /// Converts <see cref="Button"/> into <see cref="Signals.Push"/>.
        /// </summary>
        public static ITranslation<Button, Push> Push => instance;

        private static readonly ButtonInto instance = new ButtonInto();

        private ButtonInto()
        {

        }

        Touch ITranslation<Button, Touch>.Translate(Button signal)
        {
            return signal.Touch;
        }

        Push ITranslation<Button, Push>.Translate(Button signal)
        {
            return signal.Push;
        }
    }
}
