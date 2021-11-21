using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public static class HandControllerExtension
    {
        /// <summary>
        /// Converts <see cref="HandController"/> into <see cref="IIgnition{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IHandControllerProtocol"/> to convert.
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
        public static IIgnition<IHandControllerSoftware> Ignite(this IHandControllerProtocol protocol, IHandControllerConfiguration configuration)
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
        private sealed class IgniteHandController :
            IIgnition<IHandControllerSoftware>
        {
            private readonly IIgnition<IPoseTrackerSoftware> pose;

            private readonly IIgnition<IStickSoftware> thumb;

            private readonly IIgnition<ITriggerSoftware> indexFinger;

            private readonly IIgnition<ITriggerSoftware> handGrip;

            internal IgniteHandController(IHandControllerProtocol protocol, IHandControllerConfiguration configuration)
            {
                pose = protocol.Pose.Ignite(configuration.Pose);

                thumb = protocol.Thumb.Ignite(configuration.Thumb);

                indexFinger = protocol.IndexFinger.Ignite(configuration.IndexFinger);

                handGrip = protocol.HandGrip.Ignite(configuration.HandGrip);
            }

            public ICancellation Connect(IHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                pose.Emit();

                thumb.Emit();

                indexFinger.Emit();

                handGrip.Emit();
            }

            public void Dispose()
            {
                pose.Dispose();

                thumb.Dispose();

                indexFinger.Dispose();

                handGrip.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/> converted from <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHandControllerHardware> Connect(this IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHandControllerHardware(software);
        }
        private sealed class ConnectHandControllerHardware :
            IConnection<IHandControllerHardware>
        {
            private readonly IConnection<IPoseTrackerHardware> pose;

            private readonly IConnection<IStickHardware> thumb;

            private readonly IConnection<ITriggerHardware> indexFinger;

            private readonly IConnection<ITriggerHardware> handGrip;

            internal ConnectHandControllerHardware(IHandControllerSoftware software)
            {
                pose = software.Pose.Connect();

                thumb = software.Thumb.Connect();

                indexFinger = software.IndexFinger.Connect();

                handGrip = software.HandGrip.Connect();
            }

            public ICancellation Connect(IHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHandControllerSoftware> Connect(this IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectHandControllerSoftware(hardware);
        }
        private sealed class ConnectHandControllerSoftware :
            IConnection<IHandControllerSoftware>
        {
            private readonly IConnection<IPoseTrackerSoftware> pose;

            private readonly IConnection<IStickSoftware> thumb;

            private readonly IConnection<ITriggerSoftware> indexFinger;

            private readonly IConnection<ITriggerSoftware> handGrip;

            internal ConnectHandControllerSoftware(IHandControllerHardware hardware)
            {
                pose = hardware.Pose.Connect();

                thumb = hardware.Thumb.Connect();

                indexFinger = hardware.IndexFinger.Connect();

                handGrip = hardware.HandGrip.Connect();
            }

            public ICancellation Connect(IHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IHandControllerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedHandControllerHardware Pulsate(this IHandControllerHardware hardware, IHandControllerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertHandControllerInto.PulsatedHandController(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HandControllerThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedHandControllerHardware Pulsate(this IHandControllerHardware hardware, HandControllerThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.Pulsate(Nuadha.Pulsate.HandController(threshold));
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware ToPoseTracker(this IHandControllerHardware hardware, IPoseTrackerConfiguration configuration)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return hardware.Pose.Calibrate(configuration);
        }
    }
}
