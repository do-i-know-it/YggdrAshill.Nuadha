using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TSignal}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class WhenBatteryIs
    {
        /// <summary>
        /// When one <see cref="Battery"/> is same as or more than another <see cref="Battery"/>.
        /// </summary>
        public static IEvaluation<Battery> Over { get; } = new BatteryIsOver();
        private sealed class BatteryIsOver :
            IEvaluation<Battery>
        {
            public bool Evaluate(Battery signal, Battery gauge)
            {
                return gauge <= signal;
            }
        }

        /// <summary>
        /// When one <see cref="Battery"/> is same as or less than another <see cref="Battery"/>.
        /// </summary>
        public static IEvaluation<Battery> Under { get; } = new BatteryIsUnder();
        private sealed class BatteryIsUnder :
            IEvaluation<Battery>
        {
            public bool Evaluate(Battery signal, Battery gauge)
            {
                return signal <= gauge;
            }
        }
    }
}
