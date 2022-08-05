using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class NotifySignal :
        INotification<Signal>
    {
        internal bool Expected { get; set; }

        public bool Notify(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Expected;
        }
    }
}
