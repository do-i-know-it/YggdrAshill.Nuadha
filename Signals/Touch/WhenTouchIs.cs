using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TSignal}"/> and <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
    /// </summary>
    public static class WhenTouchIs
    {
        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        public static INotification<Touch> Enabled { get; } = new TouchIsEnabled();
        private sealed class TouchIsEnabled :
            INotification<Touch>
        {
            public bool Notify(Touch signal)
            {
                return (bool)signal;
            }
        }

        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        public static INotification<Touch> Disabled { get; } = new TouchIsDisabled();
        private sealed class TouchIsDisabled :
            INotification<Touch>
        {
            public bool Notify(Touch signal)
            {
                return !(bool)signal;
            }
        }

        /// <summary>
        /// When one <see cref="Touch"/> is equal to another <see cref="Touch"/>.
        /// </summary>
        public static IEvaluation<Touch> EqualTo { get; } = new TouchIsEqualTo();
        private sealed class TouchIsEqualTo :
            IEvaluation<Touch>
        {
            public bool Evaluate(Touch signal, Touch gauge)
            {
                return signal == gauge;
            }
        }

        /// <summary>
        /// When one <see cref="Touch"/> is not equal to another <see cref="Touch"/>.
        /// </summary>
        public static IEvaluation<Touch> NotEqualTo { get; } = new TouchIsNotEqualTo();
        private sealed class TouchIsNotEqualTo :
            IEvaluation<Touch>
        {
            public bool Evaluate(Touch signal, Touch gauge)
            {
                return signal != gauge;
            }
        }
    }
}
