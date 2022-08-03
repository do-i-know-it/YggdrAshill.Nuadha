using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Trigger"/>.
    /// </summary>
    public sealed class TriggerInto :
        ITranslation<Trigger, Touch>,
        ITranslation<Trigger, Pull>
    {
        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Signals.Touch"/>.
        /// </summary>
        public static ITranslation<Trigger, Touch> Touch => instance;

        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="Signals.Pull"/>.
        /// </summary>
        public static ITranslation<Trigger, Pull> Pull => instance;

        private static readonly TriggerInto instance = new TriggerInto();

        private TriggerInto()
        {

        }

        Touch ITranslation<Trigger, Touch>.Translate(Trigger signal)
        {
            return signal.Touch;
        }

        Pull ITranslation<Trigger, Pull>.Translate(Trigger signal)
        {
            return signal.Pull;
        }
    }
}
