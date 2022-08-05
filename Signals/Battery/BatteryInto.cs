using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class BatteryInto
    {
        /// <summary>
        /// Converts <see cref="Battery"/> into <see cref="Note"/>.
        /// </summary>
        public sealed class NoteIn :
            ITranslation<Battery, Note>
        {
            /// <summary>
            /// Notates <see cref="Battery"/> in ratio.
            /// </summary>
            public static ITranslation<Battery, Note> Ratio { get; }
                = new NoteIn(signal =>
                {
                    return $"{signal}";
                });

            /// <summary>
            /// Notates <see cref="Battery"/> in percent.
            /// </summary>
            public static ITranslation<Battery, Note> Percent { get; }
                = new NoteIn(signal =>
                {
                    return $"{(float)signal * 100.0f} %";
                });

            private readonly Func<Battery, string> onTranslated;

            private NoteIn(Func<Battery, string> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Note Translate(Battery signal)
            {
                return (Note)onTranslated.Invoke(signal);
            }
        }
    }
}
