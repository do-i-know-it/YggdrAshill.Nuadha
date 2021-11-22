using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectTrigger
    {
        /// <summary>
        /// Converts <see cref="ITriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/> converted from <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<ITriggerHardware> Hardware(ITriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<ITriggerHardware>
        {
            private readonly ITriggerSoftware software;

            internal ConnectHardware(ITriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(ITriggerHardware module)
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
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<ITriggerSoftware> Software(ITriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<ITriggerSoftware>
        {
            private readonly ITriggerHardware hardware;

            internal ConnectSoftware(ITriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(ITriggerSoftware module)
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
