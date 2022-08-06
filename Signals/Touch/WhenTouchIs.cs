using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Touch"/>.
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
        public static INotification<Analysis<Touch>> EqualTo { get; } = new TouchIsEqualTo();
        private sealed class TouchIsEqualTo :
            INotification<Analysis<Touch>>
        {
            
            public bool Notify(Analysis<Touch> signal)
            {
                return signal.Expected == signal.Actual;
            }
        }

        /// <summary>
        /// When one <see cref="Touch"/> is not equal to another <see cref="Touch"/>.
        /// </summary>
        public static INotification<Analysis<Touch>> NotEqualTo { get; } = new TouchIsNotEqualTo();
        private sealed class TouchIsNotEqualTo :
            INotification<Analysis<Touch>>
        {
            public bool Notify(Analysis<Touch> signal)
            {
                return signal.Expected != signal.Actual;
            }
        }
    }
}
