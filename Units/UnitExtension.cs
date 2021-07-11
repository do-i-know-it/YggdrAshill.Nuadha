using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
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

        public static IModule<IPulsatedTiltHardwareHandler, IPulsatedTiltSoftwareHandler> Convert(this IPulsatedTiltModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PulsatedTiltModule(module);
        }

        #endregion

        #region Button

        public static IModule<IButtonHardwareHandler, IButtonSoftwareHandler> Convert(this IButtonModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ButtonModule(module);
        }

        public static IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler> Convert(this IPulsatedButtonModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PulsatedButtonModule(module);
        }

        public static IButton Transmit(this IButtonModule module, IButtonConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Button(module, configuration);
        }

        public static IIgnition<IButtonHardwareHandler> Ignite(this IButton device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteButton(device);
        }

        public static IIgnition<IButtonHardwareHandler> Ignite(this IButtonModule module, IButtonConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
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

        public static IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler> Convert(this ITriggerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new TriggerModule(module);
        }

        public static IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler> Convert(this IPulsatedTriggerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PulsatedTriggerModule(module);
        }

        public static ITrigger Transmit(this ITriggerModule module, ITriggerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Trigger(module, configuration);
        }

        public static IIgnition<ITriggerHardwareHandler> Ignite(this ITrigger device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteTrigger(device);
        }

        public static IIgnition<ITriggerHardwareHandler> Ignite(this ITriggerModule module, ITriggerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
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

        public static IModule<IStickHardwareHandler, IStickSoftwareHandler> Convert(this IStickModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new StickModule(module);
        }

        public static IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler> Convert(this IPulsatedStickModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PulsatedStickModule(module);
        }

        public static IStick Transmit(this IStickModule module, IStickConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Stick(module, configuration);
        }

        public static IIgnition<IStickHardwareHandler> Ignite(this IStick device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteStick(device);
        }

        public static IIgnition<IStickHardwareHandler> Ignite(this IStickModule module, IStickConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
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

        public static IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler> Convert(this IPoseTrackerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PoseTrackerModule(module);
        }

        public static IPoseTracker Transmit(this IPoseTrackerModule module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new PoseTracker(module, configuration);
        }

        public static IIgnition<IPoseTrackerHardwareHandler> Ignite(this IPoseTracker device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgnitePoseTracker(device);
        }

        public static IIgnition<IPoseTrackerHardwareHandler> Ignite(this IPoseTrackerModule module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
        }

        public static IConnection<IPoseTrackerHardwareHandler> Calibrate(this IPoseTrackerSoftwareHandler handler, IPoseTrackerConfiguration configuration)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return new ConnectCalibratedPoseTracker(handler, configuration);
        }

        #endregion

        #region HeadTracker

        public static IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler> Convert(this IHeadTrackerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new HeadTrackerModule(module);
        }

        public static IHeadTracker Transmit(this IHeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new HeadTracker(module, configuration);
        }

        public static IIgnition<IHeadTrackerHardwareHandler> Ignite(this IHeadTracker device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteHeadTracker(device);
        }

        public static IIgnition<IHeadTrackerHardwareHandler> Ignite(this IHeadTrackerModule module, IHeadTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
        }

        #endregion

        #region HandController

        public static IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler> Convert(this IHandControllerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new HandControllerModule(module);
        }

        public static IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler> Convert(this IPulsatedHandControllerModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new PulsatedHandControllerModule(module);
        }

        public static IHandController Transmit(this IHandControllerModule module, IHandControllerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new HandController(module, configuration);
        }

        public static IIgnition<IHandControllerHardwareHandler> Ignite(this IHandController device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            return new IgniteHandController(device);
        }

        public static IIgnition<IHandControllerHardwareHandler> Ignite(this IHandControllerModule module, IHandControllerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return module.Transmit(configuration).Ignite();
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
