using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPulsatedTriggerHardware"/> and <see cref="IPulsatedTriggerSoftware"/>.
    /// </summary>
    public static class ConvertPulsatedTriggerInto
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
        public static IConnection<IPulsatedTriggerHardware> Connection(IPulsatedTriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedTriggerHardware(software);
        }
        private sealed class ConnectPulsatedTriggerHardware :
            IConnection<IPulsatedTriggerHardware>
        {
            private readonly IPulsatedTriggerSoftware software;

            internal ConnectPulsatedTriggerHardware(IPulsatedTriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedTriggerInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTriggerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/> converted from <see cref="IPulsatedTriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> Connection(IPulsatedTriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedTriggerSoftware(hardware);
        }
        private sealed class ConnectPulsatedTriggerSoftware :
            IConnection<IPulsatedTriggerSoftware>
        {
            private readonly IPulsatedTriggerHardware hardware;

            internal ConnectPulsatedTriggerSoftware(IPulsatedTriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedTriggerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPulsatedTriggerHardware hardware, IPulsatedTriggerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Pull.Produce(software.Pull))
            .Build();

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITriggerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerSoftware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static ITriggerSoftware Trigger(IPulsatedTriggerSoftware software, ITriggerPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new TriggerSoftware(software, pulsation);
        }
        private sealed class TriggerSoftware :
            ITriggerSoftware
        {
            internal TriggerSoftware(IPulsatedTriggerSoftware software, ITriggerPulsation pulsation)
            {
                Touch = ConsumeSignalTo.Convert(pulsation.Touch, software.Touch);

                Pull = ConsumeSignalTo.Convert(pulsation.Pull, software.Pull);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Pull> Pull { get; }
        }
    }
}
