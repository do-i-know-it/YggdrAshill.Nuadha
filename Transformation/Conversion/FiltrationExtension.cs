using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="IFiltration{TSignal}"/>.
    /// </summary>
    public static class FiltrationExtension
    {
        public static ICorrection<TSignal> ToCorrection<TSignal>(this IFiltration<TSignal> filtration, TSignal initial)
            where TSignal : ISignal
        {
            if (filtration == null)
            {
                throw new ArgumentNullException(nameof(filtration));
            }

            return new Correction<TSignal>(filtration, initial);
        }
        private sealed class Correction<TSignal> :
            ICorrection<TSignal>
            where TSignal : ISignal
        {
            private readonly IFiltration<TSignal> filtration;

            private TSignal previous;

            internal Correction(IFiltration<TSignal> filtration, TSignal initial)
            {
                this.filtration = filtration;
            }

            public TSignal Correct(TSignal signal)
            {
                return previous = filtration.Filtrate(signal, previous);
            }
        }

        public static IConversion<TSignal, TSignal> ToConversion<TSignal>(this IFiltration<TSignal> filtration, TSignal initial)
           where TSignal : ISignal
        {
            if (filtration == null)
            {
                throw new ArgumentNullException(nameof(filtration));
            }
           
            return filtration.ToCorrection(initial).ToConversion();
        }
    }
}
