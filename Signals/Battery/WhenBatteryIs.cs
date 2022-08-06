using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class WhenBatteryIs
    {
        /// <summary>
        /// When one <see cref="Battery"/> is same as or more than another <see cref="Battery"/>.
        /// </summary>
        public static INotification<Analysis<Battery>> Over { get; } = new BatteryIsOver();
        private sealed class BatteryIsOver :
            INotification<Analysis<Battery>>
        {
            public bool Notify(Analysis<Battery> signal)
            {
                return signal.Expected <= signal.Actual;
            }
        }

        /// <summary>
        /// When one <see cref="Battery"/> is same as or less than another <see cref="Battery"/>.
        /// </summary>
        public static INotification<Analysis<Battery>> Under { get; } = new BatteryIsUnder();
        private sealed class BatteryIsUnder :
            INotification<Analysis<Battery>>
        {
            public bool Notify(Analysis<Battery> signal)
            {
                return signal.Actual <= signal.Expected;
            }
        }
    }
}
