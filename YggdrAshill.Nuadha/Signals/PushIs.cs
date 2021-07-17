using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ICondition{TSignal}"/> for <see cref="Push"/>
    /// </summary>
    public static class PushIs
    {
        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Disabled"/>.
        /// </summary>
        public static ICondition<Push> Disabled { get; } = NoticeOf.Signal<Push>(signal => signal == Push.Disabled);

        /// <summary>
        /// When <see cref="Push"/> is <see cref="Push.Enabled"/>.
        /// </summary>
        public static ICondition<Push> Enabled { get; } = NoticeOf.Signal<Push>(signal => signal == Push.Enabled);
    }
}
