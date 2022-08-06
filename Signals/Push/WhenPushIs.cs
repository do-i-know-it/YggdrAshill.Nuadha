using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Push"/>.
    /// </summary>
    public static class WhenPushIs
    {
        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        public static INotification<Push> Enabled { get; } = new PushIsEnabled();
        private sealed class PushIsEnabled :
            INotification<Push>
        {
            public bool Notify(Push signal)
            {
                return (bool)signal;
            }
        }

        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        public static INotification<Push> Disabled { get; } = new PushIsDisabled();
        private sealed class PushIsDisabled :
            INotification<Push>
        {
            public bool Notify(Push signal)
            {
                return !(bool)signal;
            }
        }

        /// <summary>
        /// When one <see cref="Push"/> is equal to another <see cref="Push"/>.
        /// </summary>
        public static INotification<Analysis<Push>> EqualTo { get; } = new PushIsEqualTo();
        private sealed class PushIsEqualTo :
            INotification<Analysis<Push>>
        {

            public bool Notify(Analysis<Push> signal)
            {
                return signal.Expected == signal.Actual;
            }
        }

        /// <summary>
        /// When one <see cref="Push"/> is not equal to another <see cref="Push"/>.
        /// </summary>
        public static INotification<Analysis<Push>> NotEqualTo { get; } = new PushIsNotEqualTo();
        private sealed class PushIsNotEqualTo :
            INotification<Analysis<Push>>
        {
            public bool Notify(Analysis<Push> signal)
            {
                return signal.Expected != signal.Actual;
            }
        }
    }
}
