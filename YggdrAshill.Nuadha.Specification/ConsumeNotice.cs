using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class ConsumeNotice :
        IConsumption<Notice>
    {
        internal bool Consumed { get; private set; }

        public void Consume(Notice signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            Consumed = true;
        }
    }
}
