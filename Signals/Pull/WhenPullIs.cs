using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="INotification{TSignal}"/> for <see cref="Pull"/>.
    /// </summary>
    public static class WhenPullIs
    {
        /// <summary>
        /// When one <see cref="Pull"/> is same as or more than another <see cref="Pull"/>.
        /// </summary>
        public static INotification<Analysis<Pull>> Over { get; } = new PullIsOver();
        private sealed class PullIsOver :
            INotification<Analysis<Pull>>
        {
            public bool Notify(Analysis<Pull> signal)
            {
                return signal.Expected <= signal.Actual;
            }
        }

        /// <summary>
        /// When one <see cref="Pull"/> is same as or less than another <see cref="Pull"/>.
        /// </summary>
        public static INotification<Analysis<Pull>> Under { get; } = new PullIsUnder();
        private sealed class PullIsUnder :
            INotification<Analysis<Pull>>
        {
            public bool Notify(Analysis<Pull> signal)
            {
                return signal.Actual <= signal.Expected;
            }
        }
    }
}
