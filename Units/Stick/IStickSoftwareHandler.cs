using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Definition of <see cref="IHandler"/> for software for stick.
    /// </summary>
    public interface IStickSoftwareHandler :
        IHandler
    {
        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Signals.Touch"/> to software.
        /// </summary>
        IProduction<Touch> Touch { get; }

        /// <summary>
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Signals.Tilt"/> to software.
        /// </summary>
        IProduction<Tilt> Tilt { get; }
    }
}
