using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectButton
    {
        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IButtonHardware> Hardware(IButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IButtonHardware>
        {
            private readonly IButtonSoftware software;

            internal ConnectHardware(IButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IButtonHardware module)
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
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IButtonSoftware> Software(IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IButtonSoftware>
        {
            private readonly IButtonHardware hardware;

            internal ConnectSoftware(IButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IButtonSoftware module)
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
