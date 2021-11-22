using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPulsatedTilt
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
        public static IConnection<IPulsatedTiltHardware> Hardware(IPulsatedTiltSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPulsatedTiltHardware>
        {
            private readonly IPulsatedTiltSoftware software;

            internal ConnectHardware(IPulsatedTiltSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTiltHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Distance.Produce(software.Distance).Synthesize(composite);
                module.Left.Produce(software.Left).Synthesize(composite);
                module.Right.Produce(software.Right).Synthesize(composite);
                module.Forward.Produce(software.Forward).Synthesize(composite);
                module.Backward.Produce(software.Backward).Synthesize(composite);

                return composite;
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
        public static IConnection<IPulsatedTiltSoftware> Software(IPulsatedTiltHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPulsatedTiltSoftware>
        {
            private readonly IPulsatedTiltHardware hardware;

            internal ConnectSoftware(IPulsatedTiltHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTiltSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Distance.Produce(module.Distance).Synthesize(composite);
                hardware.Left.Produce(module.Left).Synthesize(composite);
                hardware.Right.Produce(module.Right).Synthesize(composite);
                hardware.Forward.Produce(module.Forward).Synthesize(composite);
                hardware.Backward.Produce(module.Backward).Synthesize(composite);

                return composite;
            }
        }
    }
}
