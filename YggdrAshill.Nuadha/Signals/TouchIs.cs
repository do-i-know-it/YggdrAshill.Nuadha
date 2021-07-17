using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ICondition{TSignal}"/> for <see cref="Touch"/>
    /// </summary>
    public static class TouchIs
    {
        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Disabled"/>.
        /// </summary>
        public static ICondition<Touch> Disabled { get; } = NoticeOf.Signal<Touch>(signal => signal == Touch.Disabled);

        /// <summary>
        /// When <see cref="Touch"/> is <see cref="Touch.Enabled"/>.
        /// </summary>
        public static ICondition<Touch> Enabled { get; } = NoticeOf.Signal<Touch>(signal => signal == Touch.Enabled);
    }
}
