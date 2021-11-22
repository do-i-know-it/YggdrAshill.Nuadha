using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectStick
    {
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
        public static IConnection<IStickHardware> Hardware(IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IStickHardware>
        {
            private readonly IStickSoftware software;

            internal ConnectHardware(IStickSoftware software)
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
        public static IConnection<IStickSoftware> Software(IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IStickSoftware>
        {
            private readonly IStickHardware hardware;

            internal ConnectSoftware(IStickHardware hardware)
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

    }
}
