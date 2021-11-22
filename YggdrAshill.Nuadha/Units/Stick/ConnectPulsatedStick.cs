using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPulsatedStick
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
        public static IConnection<IPulsatedStickHardware> Hardware(IPulsatedStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPulsatedStickHardware>
        {
            private readonly IPulsatedStickSoftware software;

            internal ConnectHardware(IPulsatedStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Tilt.Distance.Produce(software.Tilt.Distance).Synthesize(composite);
                module.Tilt.Left.Produce(software.Tilt.Left).Synthesize(composite);
                module.Tilt.Right.Produce(software.Tilt.Right).Synthesize(composite);
                module.Tilt.Forward.Produce(software.Tilt.Forward).Synthesize(composite);
                module.Tilt.Backward.Produce(software.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/> converted from <see cref="IPulsatedStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickSoftware> Software(IPulsatedStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPulsatedStickSoftware>
        {
            private readonly IPulsatedStickHardware hardware;

            internal ConnectSoftware(IPulsatedStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Tilt.Distance.Produce(module.Tilt.Distance).Synthesize(composite);
                hardware.Tilt.Left.Produce(module.Tilt.Left).Synthesize(composite);
                hardware.Tilt.Right.Produce(module.Tilt.Right).Synthesize(composite);
                hardware.Tilt.Forward.Produce(module.Tilt.Forward).Synthesize(composite);
                hardware.Tilt.Backward.Produce(module.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }
    }
}
