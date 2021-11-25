using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPulsatedTiltHardware"/> and <see cref="IPulsatedTiltSoftware"/>.
    /// </summary>
    public static class ConvertPulsatedTiltInto
    {
        /// <summary>
        /// Converts <see cref="IPulsatedTiltSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltHardware"/> converted from <see cref="IPulsatedTiltSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltHardware> Connection(IPulsatedTiltSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedTiltHardware(software);
        }
        private sealed class ConnectPulsatedTiltHardware :
            IConnection<IPulsatedTiltHardware>
        {
            private readonly IPulsatedTiltSoftware software;

            internal ConnectPulsatedTiltHardware(IPulsatedTiltSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTiltHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedTiltInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTiltHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTiltHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltSoftware> Connection(IPulsatedTiltHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedTiltSoftware(hardware);
        }
        private sealed class ConnectPulsatedTiltSoftware :
            IConnection<IPulsatedTiltSoftware>
        {
            private readonly IPulsatedTiltHardware hardware;

            internal ConnectPulsatedTiltSoftware(IPulsatedTiltHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTiltSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedTiltInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPulsatedTiltHardware hardware, IPulsatedTiltSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Distance.Produce(software.Distance))
            .Synthesize(hardware.Left.Produce(software.Left))
            .Synthesize(hardware.Right.Produce(software.Right))
            .Synthesize(hardware.Forward.Produce(software.Forward))
            .Synthesize(hardware.Backward.Produce(software.Backward))
            .Build();

        /// <summary>
        /// Converts <see cref="IPulsatedTiltHardware"/> into <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITiltPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Signals.Tilt"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IConsumption<Tilt> Tilt(IPulsatedTiltSoftware software, ITiltPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new ConsumeTilt(software, pulsation);
        }
        private sealed class ConsumeTilt :
            IConsumption<Tilt>
        {
            private readonly IConsumption<Tilt> distance;

            private readonly IConsumption<Tilt> left;

            private readonly IConsumption<Tilt> right;

            private readonly IConsumption<Tilt> forward;

            private readonly IConsumption<Tilt> backward;

            internal ConsumeTilt(IPulsatedTiltSoftware software, ITiltPulsation pulsation)
            {
                distance = ConsumeSignalTo.Convert(pulsation.Distance, software.Distance);
                left = ConsumeSignalTo.Convert(pulsation.Left, software.Left);
                right = ConsumeSignalTo.Convert(pulsation.Right, software.Right);
                forward = ConsumeSignalTo.Convert(pulsation.Forward, software.Forward);
                backward = ConsumeSignalTo.Convert(pulsation.Backward, software.Backward);
            }

            public void Consume(Tilt signal)
            {
                distance.Consume(signal);
                left.Consume(signal);
                right.Consume(signal);
                forward.Consume(signal);
                backward.Consume(signal);
            }
        }
    }
}
