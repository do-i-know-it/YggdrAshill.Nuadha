﻿using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signalization
{
    public interface IGenerator<TSignal> :
        IOutputTerminal<TSignal>,
        IIgnitor,
        IDisconnection
        where TSignal : ISignal
    {

    }
}