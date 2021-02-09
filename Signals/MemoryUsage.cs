﻿using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct MemoryUsage :
        ISignal,
        IEquatable<MemoryUsage>
    {
        public long UsedSize { get; }

        public long UnusedSize { get; }

        public MemoryUsage(long usedSize, long unusedSize)
        {
            if (usedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(usedSize));
            }
            if (unusedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unusedSize));
            }

            UsedSize = usedSize;

            UnusedSize = unusedSize;
        }

        public long TotalSize
            => UsedSize + UnusedSize;

        public bool Equals(MemoryUsage other)
        {
            return UsedSize.Equals(other.UsedSize)
                && UnusedSize.Equals(other.UnusedSize);
        }
    }
}
