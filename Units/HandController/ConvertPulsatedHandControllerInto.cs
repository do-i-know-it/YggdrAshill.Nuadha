using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPulsatedHandControllerHardware"/> and <see cref="IPulsatedHandControllerSoftware"/>.
    /// </summary>
    public static class ConvertPulsatedHandControllerInto
    {
        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IPulsatedHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerHardware> Connection(IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedHandControllerHardware(software);
        }
        private sealed class ConnectPulsatedHandControllerHardware :
            IConnection<IPulsatedHandControllerHardware>
        {
            private readonly IPulsatedHandControllerSoftware software;

            internal ConnectPulsatedHandControllerHardware(IPulsatedHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedHandControllerHardware hardware)
            {
                if (hardware == null)
                {
                    throw new ArgumentNullException(nameof(hardware));
                }

                return ConvertPulsatedHandControllerInto.Connect(hardware, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedHandControllerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/> converted from <see cref="IPulsatedHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerSoftware> Connection(IPulsatedHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedHandControllerSoftware(hardware);
        }
        private sealed class ConnectPulsatedHandControllerSoftware :
            IConnection<IPulsatedHandControllerSoftware>
        {
            private readonly IPulsatedHandControllerHardware hardware;

            internal ConnectPulsatedHandControllerSoftware(IPulsatedHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedHandControllerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPulsatedHandControllerHardware hardware, IPulsatedHandControllerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.IndexFinger.Touch.Produce(software.IndexFinger.Touch))
            .Synthesize(hardware.IndexFinger.Pull.Produce(software.IndexFinger.Pull))
            .Synthesize(hardware.HandGrip.Touch.Produce(software.HandGrip.Touch))
            .Synthesize(hardware.HandGrip.Pull.Produce(software.HandGrip.Pull))
            .Synthesize(hardware.Thumb.Touch.Produce(software.Thumb.Touch))
            .Synthesize(hardware.Thumb.Tilt.Distance.Produce(software.Thumb.Tilt.Distance))
            .Synthesize(hardware.Thumb.Tilt.Left.Produce(software.Thumb.Tilt.Left))
            .Synthesize(hardware.Thumb.Tilt.Right.Produce(software.Thumb.Tilt.Right))
            .Synthesize(hardware.Thumb.Tilt.Forward.Produce(software.Thumb.Tilt.Forward))
            .Synthesize(hardware.Thumb.Tilt.Backward.Produce(software.Thumb.Tilt.Backward))
            .Build();
    }
}
