using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    internal sealed class SignalCondition :
        INotification<Signal>
    {
        internal bool Previous { get; set; }

        public bool Notify(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return Previous;
        }
    }
}
