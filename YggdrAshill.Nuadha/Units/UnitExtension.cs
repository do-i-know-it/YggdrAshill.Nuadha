using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public static class UnitExtension
    {
        public static IConnection<IPulsatedTiltHardwareHandler> Pulsated(this IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PulsatedTilt(production, threshold);
        }

        public static IConnection<IPulsatedButtonHardwareHandler> Pulsated(this IButtonSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return new PulsatedButton(handler);
        }

        public static IConnection<IPulsatedTriggerHardwareHandler> Pulsated(this ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PulsatedTrigger(handler, threshold);
        }

        public static IConnection<IPulsatedStickHardwareHandler> Pulsated(this IStickSoftwareHandler handler, TiltThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PulsatedStick(handler, threshold);
        }

        public static IConnection<IPulsatedHandControllerHardwareHandler> Pulsated(this IHandControllerSoftwareHandler handler, HandControllerThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PulsatedHandController(handler, threshold);
        }
    }
}
