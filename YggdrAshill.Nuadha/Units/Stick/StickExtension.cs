using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IStickHardware"/> and <see cref="IStickSoftware"/>.
    /// </summary>
    public static class StickExtension
    {
        /// <summary>
        /// Converts <see cref="IStickProtocol"/> into <see cref="IIgnition{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IStickProtocol"/> to convert.
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
        public static IIgnition<IStickSoftware> Ignite(this IStickProtocol protocol, IStickConfiguration configuration)
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
        private sealed class IgniteStick :
            IIgnition<IStickSoftware>
        {
            private readonly ITransmission<Touch> touch;

            private readonly ITransmission<Tilt> tilt;

            internal IgniteStick(IStickProtocol protocol, IStickConfiguration configuration)
            {
                touch = protocol.Touch.Ignite(configuration.Touch);

                tilt = protocol.Tilt.Ignite(configuration.Tilt);
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                tilt.Produce(module.Tilt).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                touch.Emit();

                tilt.Emit();
            }

            public void Dispose()
            {
                touch.Dispose();

                tilt.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="IStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/> converted from <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IStickHardware> Connect(this IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectStickHardware(software);
        }
        private sealed class ConnectStickHardware :
            IConnection<IStickHardware>
        {
            private readonly IStickSoftware software;

            internal ConnectStickHardware(IStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Tilt.Produce(software.Tilt).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IStickSoftware> Connect(this IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectStickSoftware(hardware);
        }
        private sealed class ConnectStickSoftware :
            IConnection<IStickSoftware>
        {
            private readonly IStickHardware hardware;

            internal ConnectStickSoftware(IStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Tilt.Produce(module.Tilt).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IStickPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedStickHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedStickHardware Pulsate(this IStickHardware hardware, IStickPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertStickInto.PulsatedStick(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedStickHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedStickHardware Pulsate(this IStickHardware hardware, TiltThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.Pulsate(Nuadha.Pulsate.Stick(threshold));
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITriggerHardware ToTrigger(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertStickInto.Trigger(hardware, translation);
        }
    }
}
