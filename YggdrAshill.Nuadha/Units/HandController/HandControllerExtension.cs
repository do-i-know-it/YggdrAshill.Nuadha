using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="HandController"/>.
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

        [Obsolete("Please use HandControllerExtension.Pulsate instead.")]
        public static IConnection<IPulsatedHandControllerSoftware> Convert(this IHandControllerHardware module, HandControllerThreshold threshold)
        {
            return module.Pulsate(threshold);
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
        public static IConnection<IPulsatedHandControllerSoftware> Pulsate(this IHandControllerHardware module, HandControllerThreshold threshold)
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
        private sealed class ConnectPulsatedHandController :
            IConnection<IPulsatedHandControllerSoftware>
        {
            private readonly IConnection<IPulsatedStickSoftware> thumb;

            private readonly IConnection<IPulsatedTriggerSoftware> indexFinger;

            private readonly IConnection<IPulsatedTriggerSoftware> handGrip;

            internal ConnectPulsatedHandController(IHandControllerHardware module, HandControllerThreshold threshold)
            {
                thumb = module.Thumb.Pulsate(threshold.Thumb);

                indexFinger = module.IndexFinger.Pulsate(threshold.IndexFinger);

                handGrip = module.HandGrip.Pulsate(threshold.HandGrip);
            }

            public ICancellation Connect(IPulsatedHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

                return composite;
            }
        }
    }
}
