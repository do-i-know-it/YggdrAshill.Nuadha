﻿using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class MediumSignal : ISignal
    {
        public OutputSignal OutputSignal { get; } = new();
    }
}
