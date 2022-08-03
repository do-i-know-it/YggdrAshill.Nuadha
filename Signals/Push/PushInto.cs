using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Push"/>.
    /// </summary>
    public sealed class PushInto :
        ITranslation<Push, Touch>,
        ITranslation<Push, Pull>
    {
        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Push, Touch> Touch => instance;

        /// <summary>
        /// Converts <see cref="Push"/> into <see cref="Signals.Pull"/>.
        /// </summary>
        public static ITranslation<Push, Pull> Pull => instance;

        private static readonly PushInto instance = new PushInto();

        private PushInto()
        {

        }

        Touch ITranslation<Push, Touch>.Translate(Push signal)
        {
            return (Touch)signal;
        }

        Pull ITranslation<Push, Pull>.Translate(Push signal)
        {
            return (Pull)signal;
        }
    }
}
