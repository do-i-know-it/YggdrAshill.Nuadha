﻿using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Unitization
{
    public interface IOutputSystem<TSoftwareHandler> :
        ISoftware<TSoftwareHandler>,
        IDisconnection,
        IIgnitor
        where TSoftwareHandler : ISoftwareHandler
    {

    }
}
