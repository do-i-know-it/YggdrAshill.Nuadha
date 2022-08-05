using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IEvaluation{TSignal}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class WhenPullIs
    {
        /// <summary>
        /// When one <see cref="Pull"/> is same as or more than another <see cref="Pull"/>.
        /// </summary>
        public static IEvaluation<Pull> Over { get; } = new PullIsOver();
        private sealed class PullIsOver :
            IEvaluation<Pull>
        {
            public bool Evaluate(Pull signal, Pull gauge)
            {
                return gauge <= signal;
            }
        }

        /// <summary>
        /// When one <see cref="Pull"/> is same as or less than another <see cref="Pull"/>.
        /// </summary>
        public static IEvaluation<Pull> Under { get; } = new PullIsUnder();
        private sealed class PullIsUnder :
            IEvaluation<Pull>
        {
            public bool Evaluate(Pull signal, Pull gauge)
            {
                return signal <= gauge;
            }
        }
    }
}
