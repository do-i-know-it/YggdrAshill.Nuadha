using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public static class MemoryUsageInto
    {
        /// <summary>
        /// Converts <see cref="MemoryUsage"/> into <see cref="Note"/>.
        /// </summary>
        public sealed class NoteIn :
            ITranslation<MemoryUsage, Note>
        {
            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in byte.
            /// </summary>
            public static ITranslation<MemoryUsage, Note> Byte { get; }
                = new NoteIn(signal =>
                {
                    var totalByte = signal.TotalSize;
                    var usedByte = signal.UsedSize;
                    var unusedByte = signal.UnusedSize;

                    return $"{totalByte} B in total ({usedByte} B used, {unusedByte} B)";
                });

            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in kilo byte.
            /// </summary>
            public static ITranslation<MemoryUsage, Note> KiloByte { get; }
                = new NoteIn(signal =>
                {
                    var totalKiloByte = signal.TotalSize * MemoryUsage.ByteToKiloByte;
                    var usedKiloByte = signal.UsedSize * MemoryUsage.ByteToKiloByte;
                    var unusedKiloByte = signal.UnusedSize * MemoryUsage.ByteToKiloByte;

                    return $"{totalKiloByte} KB in total ({usedKiloByte} KB used, {unusedKiloByte} KB)";
                });

            /// <summary>
            /// Notates <see cref="MemoryUsage"/> in mega byte.
            /// </summary>
            public static ITranslation<MemoryUsage, Note> MegaByte { get; }
                = new NoteIn(signal =>
                {
                    var totalMegaByte = signal.TotalSize * MemoryUsage.ByteToMegaByte;
                    var usedMegaByte = signal.UsedSize * MemoryUsage.ByteToMegaByte;
                    var unusedMegaByte = signal.UnusedSize * MemoryUsage.ByteToMegaByte;

                    return $"{totalMegaByte} MB in total ({usedMegaByte} MB used, {unusedMegaByte} MB)";
                });

            private readonly Func<MemoryUsage, string> onTranslated;

            private NoteIn(Func<MemoryUsage, string> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Note Translate(MemoryUsage signal)
            {
                return (Note)onTranslated.Invoke(signal);
            }
        }
    }
}
