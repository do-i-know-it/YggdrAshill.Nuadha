﻿using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IPullEventSystem :
        IConnection<Pull>,
        IPullEventHandler,
        IDisconnection
    {

    }
}