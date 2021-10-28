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
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTiltSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltSoftware> Convert(this IProduction<Tilt> production, TiltThreshold threshold)
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
        /// Converts <see cref="Button"/> into <see cref="IIgnition{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="Button"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IButtonSoftware> Convert(this Button protocol, IButtonConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteButton(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> Convert(this IButtonHardware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedButton(module);
        }

        #endregion

        #region Trigger

        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="IIgnition{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="Trigger"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<ITriggerSoftware> Convert(this Trigger protocol, ITriggerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteTrigger(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> Convert(this ITriggerHardware module, HysteresisThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTrigger(module, threshold);
        }

        #endregion

        #region Stick

        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="IIgnition{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="Stick"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IStickSoftware> Convert(this Stick protocol, IStickConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteStick(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickSoftware> Convert(this IStickHardware module, TiltThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedStick(module, threshold);
        }

        #endregion

        #region PoseTracker

        /// <summary>
        /// Converts <see cref="PoseTracker"/> into <see cref="IIgnition{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="PoseTracker"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IPoseTrackerSoftware> Convert(this PoseTracker protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgnitePoseTracker(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPoseTrackerHardware"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerSoftware> Convert(this IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectCalibratedPoseTracker(module, configuration);
        }

        #endregion

        #region HeadTracker

        /// <summary>
        /// Converts <see cref="HeadTracker"/> into <see cref="IIgnition{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="HeadTracker"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHeadTrackerSoftware> Convert(this HeadTracker protocol, IHeadTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHeadTracker(protocol, configuration);
        }

        #endregion

        #region HandController

        /// <summary>
        /// Converts <see cref="HandController"/> into <see cref="IIgnition{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="HandController"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHandControllerSoftware> Convert(this HandController protocol, IHandControllerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHandController(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HandControllerThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerSoftware> Convert(this IHandControllerHardware module, HandControllerThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedHandController(module, threshold);
        }

        #endregion
    }
}
