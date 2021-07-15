using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for trigger.
    /// </summary>
    public interface ITriggerSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Signals.Pull"/> to software.
        /// </summary>
        IProduction<Pull> Pull { get; }
    }
}
