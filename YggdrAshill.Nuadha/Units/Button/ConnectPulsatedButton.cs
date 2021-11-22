using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPulsatedButton
    {
        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonHardware> Hardware(IPulsatedButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPulsatedButtonHardware>
        {
            private readonly IPulsatedButtonSoftware software;

            internal ConnectHardware(IPulsatedButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Push.Produce(software.Push).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/> converted from <see cref="IPulsatedButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> Software(IPulsatedButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPulsatedButtonSoftware>
        {
            private readonly IPulsatedButtonHardware hardware;

            internal ConnectSoftware(IPulsatedButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Push.Produce(module.Push).Synthesize(composite);

                return composite;
            }
        }
    }
}
