using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    public static class CorrectionExtension
    {
        public static ICorrection<TSignal> Then<TSignal>(this ICorrection<TSignal> correction, ICorrection<TSignal> hoge)
            where TSignal : ISignal
        {
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }
            if (hoge == null)
            {
                throw new ArgumentNullException(nameof(hoge));
            }

            return new Intermediate<TSignal>(correction, hoge);
        }
        private sealed class Intermediate<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly ICorrection<TSignal> correction;

            private readonly ICorrection<TSignal> hoge;

            internal Intermediate(ICorrection<TSignal> correction, ICorrection<TSignal> hoge)
            {
                this.correction = correction;

                this.hoge = hoge;
            }

            /// <inheritdoc/>
            public TSignal Correct(TSignal signal)
            {
                var medium = correction.Correct(signal);

                return hoge.Correct(medium);
            }
        }
    }
}
