using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Battery"/>.
    /// </summary>
    public static class FromBattery
    {
        /// <summary>
        /// Converts <see cref="Battery"/> into <see cref="Note"/>.
        /// </summary>
        public static class IntoNoteIn
        {
            /// <summary>
            /// Notates <see cref="Battery"/> in ratio.
            /// </summary>
            public static IConversion<Battery, Note> Ratio { get; } = IntoNoteFrom<Battery>.Like(signal => $"{nameof(Battery)}: {signal}");

            /// <summary>
            /// Notates <see cref="Battery"/> in percent.
            /// </summary>
            public static IConversion<Battery, Note> Percent { get; } = IntoNoteFrom<Battery>.Like(signal => $"{nameof(Battery)}: {(float)signal * 100.0f} %");
        }
    }
}
