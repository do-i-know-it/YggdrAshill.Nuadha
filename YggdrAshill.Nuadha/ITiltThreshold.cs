﻿using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface ITiltThreshold
    {
        HysteresisThreshold Left { get; }

        HysteresisThreshold Right { get; }

        HysteresisThreshold Forward { get; }

        HysteresisThreshold Backward { get; }
    }
}