using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPulsatedTrigger
    {
        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerHardware> Hardware(IPulsatedTriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPulsatedTriggerHardware>
        {
            private readonly IPulsatedTriggerSoftware software;

            internal ConnectHardware(IPulsatedTriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Pull.Produce(software.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/> converted from <see cref="IPulsatedTriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> Software(IPulsatedTriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPulsatedTriggerSoftware>
        {
            private readonly IPulsatedTriggerHardware hardware;

            internal ConnectSoftware(IPulsatedTriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Pull.Produce(module.Pull).Synthesize(composite);

                return composite;
            }
        }
    }
}
