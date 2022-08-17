using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    public static class IntoBufferFrom<TSignal>
        where TSignal : ISignal
    {
        public static IConversion<TSignal, Sequence<TSignal>> With(TSignal initial)
        {
            return new FromSignalIntoSequence(initial);
        }
        private sealed class FromSignalIntoSequence :
            IConversion<TSignal, Sequence<TSignal>>
        {
            private TSignal previous;

            public FromSignalIntoSequence(TSignal previous)
            {
                this.previous = previous;
            }

            public Sequence<TSignal> Convert(TSignal signal)
            {
                var sequence = new Sequence<TSignal>(previous, signal);

                previous = signal;

                return sequence;
            }
        }

        public static IConversion<TSignal, Analysis<TSignal>> With(ITarget<TSignal> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new FromSignalIntoAnalysis(target);
        }
        private sealed class FromSignalIntoAnalysis :
            IConversion<TSignal, Analysis<TSignal>>
        {
            private readonly ITarget<TSignal> target;

            public FromSignalIntoAnalysis(ITarget<TSignal> target)
            {
                this.target = target;
            }

            public Analysis<TSignal> Convert(TSignal signal)
            {
                return new Analysis<TSignal>(target.Signal, signal);
            }
        }

        public static IConversion<TSignal, Accuracy<TSignal>> With(IError<TSignal> error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return new FromSignalIntoAccuracy(error);
        }
        private sealed class FromSignalIntoAccuracy :
            IConversion<TSignal, Accuracy<TSignal>>
        {
            private readonly IError<TSignal> error;

            public FromSignalIntoAccuracy(IError<TSignal> error)
            {
                this.error = error;
            }

            public Accuracy<TSignal> Convert(TSignal signal)
            {
                return new Accuracy<TSignal>(signal, error.Signal);
            }
        }
    }
}
