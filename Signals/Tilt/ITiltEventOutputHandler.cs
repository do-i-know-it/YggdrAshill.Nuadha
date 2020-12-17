﻿using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventOutputHandler :
        ISoftwareHandler
    {
        IPulseEventOutputHandler Left { get; }

        IPulseEventOutputHandler Right { get; }

        IPulseEventOutputHandler Forward { get; }

        IPulseEventOutputHandler Backward { get; }
    }
}
