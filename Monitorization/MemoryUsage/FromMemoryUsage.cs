using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public static class FromMemoryUsage
    {
        /// <summary>
        /// Converts <see cref="MemoryUsage"/> into <see cref="Note"/>.
        /// </summary>
        public static class IntoNoteIn
        {
            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in byte.
            /// </summary>
            public static IConversion<MemoryUsage, Note> Byte { get; }
                = IntoNoteFrom<MemoryUsage>.Like(signal =>
                {
                    var totalByte = signal.Total;
                    var usedByte = signal.Used;
                    var unusedByte = signal.Unused;

                    return $"{nameof(MemoryUsage)}: {totalByte} B in total ({usedByte} B used, {unusedByte} B)";
                });

            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in kilo byte.
            /// </summary>
            public static IConversion<MemoryUsage, Note> KiloByte { get; }
                = IntoNoteFrom<MemoryUsage>.Like(signal =>
                {
                    var totalKiloByte = signal.Total * MemoryUsage.ByteToKiloByte;
                    var usedKiloByte = signal.Used * MemoryUsage.ByteToKiloByte;
                    var unusedKiloByte = signal.Unused * MemoryUsage.ByteToKiloByte;

                    return $"{nameof(MemoryUsage)}: {totalKiloByte} KB in total ({usedKiloByte} KB used, {unusedKiloByte} KB)";
                });

            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in mega byte.
            /// </summary>
            public static IConversion<MemoryUsage, Note> MegaByte { get; }
                = IntoNoteFrom<MemoryUsage>.Like(signal =>
                {
                    var totalMegaByte = signal.Total * MemoryUsage.ByteToMegaByte;
                    var usedMegaByte = signal.Used * MemoryUsage.ByteToMegaByte;
                    var unusedMegaByte = signal.Unused * MemoryUsage.ByteToMegaByte;

                    return $"{nameof(MemoryUsage)}: {totalMegaByte} MB in total ({usedMegaByte} MB used, {unusedMegaByte} MB)";
                });
        }
    }
}
