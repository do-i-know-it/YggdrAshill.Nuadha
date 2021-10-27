using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Units.
    /// </summary>
    public static class UnitExtension
    {
        #region Signals

        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedTiltHardwareHandler"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedTiltHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
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

        /// <summary>
        /// Converts <see cref="ButtonModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="IButtonHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="ButtonModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="IButtonHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IButtonHardwareHandler> Convert(this ButtonModule module, IButtonConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="IButtonSoftwareHandler"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedButtonHardwareHandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <see cref="IButtonSoftwareHandler"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedButtonHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handler"/> is null.
        /// </exception>
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

        /// <summary>
        /// Converts <see cref="TriggerModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="ITriggerHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="TriggerModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="ITriggerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<ITriggerHardwareHandler> Convert(this TriggerModule module, ITriggerConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="ITriggerSoftwareHandler"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedTriggerHardwareHandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <see cref="ITriggerSoftwareHandler"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedTriggerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
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

        /// <summary>
        /// Converts <see cref="StickModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="IStickHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="StickModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="IStickHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IStickHardwareHandler> Convert(this StickModule module, IStickConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="IStickSoftwareHandler"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedStickHardwareHandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <see cref="IStickSoftwareHandler"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedStickHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
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

        /// <summary>
        /// Converts <see cref="PoseTrackerModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="IPoseTrackerHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="PoseTrackerModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="IPoseTrackerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IPoseTrackerHardwareHandler> Convert(this PoseTrackerModule module, IPoseTrackerConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="IPoseTrackerSoftwareHandler"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPoseTrackerHardwareHandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <see cref="IPoseTrackerSoftwareHandler"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPoseTrackerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
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

        /// <summary>
        /// Converts <see cref="HeadTrackerModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="IHeadTrackerHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="HeadTrackerModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="IHeadTrackerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHeadTrackerHardwareHandler> Convert(this HeadTrackerModule module, IHeadTrackerConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="HandControllerModule"/> into <see cref="IIgnition{THandler}"/> to ignite <see cref="IHandControllerHardwareHandler"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="HandControllerModule"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{THandler}"/> to ignite <see cref="IHandControllerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHandControllerHardwareHandler> Convert(this HandControllerModule module, IHandControllerConfiguration configuration)
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

        /// <summary>
        /// Converts <see cref="IHandControllerSoftwareHandler"/> into <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedHandControllerHardwareHandler"/>.
        /// </summary>
        /// <param name="handler">
        /// <see cref="IHandControllerSoftwareHandler"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HandControllerThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{THandler}"/> to connect <see cref="IPulsatedHandControllerHardwareHandler"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="handler"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
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
