using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha
{
    public static class UnitExtension
    {
        #region Signals

        public static IConnection<IPulsatedTiltHardwareHandler> Convert(this IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTilt(production, threshold);
        }

        #endregion

        #region Button

        public static IIgnition<IButtonHardwareHandler> Convert(this IButton device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteButton(device);
        }

        public static IConnection<IPulsatedButtonHardwareHandler> Convert(this IButtonSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return new ConnectPulsatedButton(handler);
        }

        #endregion

        #region Trigger

        public static IIgnition<ITriggerHardwareHandler> Convert(this ITrigger device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteTrigger(device);
        }

        public static IConnection<IPulsatedTriggerHardwareHandler> Convert(this ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTrigger(handler, threshold);
        }

        #endregion

        #region Stick

        public static IIgnition<IStickHardwareHandler> Convert(this IStick device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteStick(device);
        }

        public static IConnection<IPulsatedStickHardwareHandler> Convert(this IStickSoftwareHandler handler, TiltThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedStick(handler, threshold);
        }

        #endregion

        #region PoseTracker

        public static IIgnition<IPoseTrackerHardwareHandler> Convert(this IPoseTracker device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgnitePoseTracker(device);
        }

        #endregion

        #region HeadTracker

        public static IIgnition<IHeadTrackerHardwareHandler> Convert(this IHeadTracker device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteHeadTracker(device);
        }

        #endregion

        #region HandController

        public static IIgnition<IHandControllerHardwareHandler> Convert(this IHandController device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteHandController(device);
        }

        public static IConnection<IPulsatedHandControllerHardwareHandler> Convert(this IHandControllerSoftwareHandler handler, HandControllerThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedHandController(handler, threshold);
        }

        #endregion
    }
}
