﻿using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    internal sealed class Pulsate<TSignal> :
        IConversion<TSignal, Pulse>
        where TSignal : ISignal
    {
        private readonly IPulsation<TSignal> pulsation;

        internal Pulsate(IPulsation<TSignal> pulsation)
        {
            this.pulsation = pulsation;
        }

        public Pulse Convert(TSignal signal)
        {
            return pulsation.Pulsate(signal);
        }
    }
}