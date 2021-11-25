using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPulsatedStickHardware"/> and <see cref="IPulsatedStickSoftware"/>.
    /// </summary>
    public static class ConvertPulsatedStickInto
    {
        /// <summary>
        /// Converts <see cref="IPulsatedStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/> converted from <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickHardware> Connection(IPulsatedStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedStickHardware(software);
        }
        private sealed class ConnectPulsatedStickHardware :
            IConnection<IPulsatedStickHardware>
        {
            private readonly IPulsatedStickSoftware software;

            internal ConnectPulsatedStickHardware(IPulsatedStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedStickInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedStickHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/> converted from <see cref="IPulsatedStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickSoftware> Connection(IPulsatedStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedStickSoftware(hardware);
        }
        private sealed class ConnectPulsatedStickSoftware :
            IConnection<IPulsatedStickSoftware>
        {
            private readonly IPulsatedStickHardware hardware;

            internal ConnectPulsatedStickSoftware(IPulsatedStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedStickInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPulsatedStickHardware hardware, IPulsatedStickSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Tilt.Distance.Produce(software.Tilt.Distance))
            .Synthesize(hardware.Tilt.Left.Produce(software.Tilt.Left))
            .Synthesize(hardware.Tilt.Right.Produce(software.Tilt.Right))
            .Synthesize(hardware.Tilt.Forward.Produce(software.Tilt.Forward))
            .Synthesize(hardware.Tilt.Backward.Produce(software.Tilt.Backward))
            .Build();

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IStickPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IStickSoftware"/> converted from <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IStickSoftware Stick(IPulsatedStickSoftware software, IStickPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new StickSoftware(software, pulsation);
        }
        private sealed class StickSoftware :
            IStickSoftware
        {
            internal StickSoftware(IPulsatedStickSoftware software, IStickPulsation pulsation)
            {
                Touch = ConsumeSignalTo.Convert(pulsation.Touch, software.Touch);

                Tilt = ConvertPulsatedTiltInto.Tilt(software.Tilt, pulsation.Tilt);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Tilt> Tilt { get; }
        }
    }
}
