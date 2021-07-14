using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

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

        public static IIgnition<IButtonHardwareHandler> Ignite(this ButtonModule module, IButtonConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteButton(module, configuration);
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

        public static IIgnition<ITriggerHardwareHandler> Ignite(this TriggerModule module, ITriggerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteTrigger(module, configuration);
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

        public static IIgnition<IStickHardwareHandler> Ignite(this StickModule module, IStickConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteStick(module, configuration);
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

        public static IIgnition<IPoseTrackerHardwareHandler> Ignite(this PoseTrackerModule module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgnitePoseTracker(module, configuration);
        }

        public static IConnection<IPoseTrackerHardwareHandler> Convert(this IPoseTrackerSoftwareHandler handler, IPoseTrackerConfiguration configuration)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return new ConnectCalibratedPoseTracker(handler, configuration);
        }

        #endregion

        #region HeadTracker

        public static IIgnition<IHeadTrackerHardwareHandler> Ignite(this HeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHeadTracker(module, configuration);
        }

        #endregion

        #region HandController

        public static IIgnition<IHandControllerHardwareHandler> Ignite(this HandControllerModule module, IHandControllerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHandController(module, configuration);
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
