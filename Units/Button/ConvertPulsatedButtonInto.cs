using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPulsatedButtonHardware"/> and <see cref="IPulsatedButtonSoftware"/>.
    /// </summary>
    public static class ConvertPulsatedButtonInto
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
        public static IConnection<IPulsatedButtonHardware> Connection(IPulsatedButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedButtonHardware(software);
        }
        private sealed class ConnectPulsatedButtonHardware :
            IConnection<IPulsatedButtonHardware>
        {
            private readonly IPulsatedButtonSoftware software;

            internal ConnectPulsatedButtonHardware(IPulsatedButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedButtonInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/> converted from <see cref="IPulsatedButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> Connection(IPulsatedButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedButtonSoftware(hardware);
        }
        private sealed class ConnectPulsatedButtonSoftware :
            IConnection<IPulsatedButtonSoftware>
        {
            private readonly IPulsatedButtonHardware hardware;

            internal ConnectPulsatedButtonSoftware(IPulsatedButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPulsatedButtonInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPulsatedButtonHardware hardware, IPulsatedButtonSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Push.Produce(software.Push))
            .Build();

        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IButtonPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IButtonSoftware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IButtonSoftware Button(IPulsatedButtonSoftware software, IButtonPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new ButtonSoftware(software, pulsation);
        }
        private sealed class ButtonSoftware :
            IButtonSoftware
        {
            internal ButtonSoftware(IPulsatedButtonSoftware software, IButtonPulsation pulsation)
            {
                Touch = ConsumeSignalTo.Convert(pulsation.Touch, software.Touch);

                Push = ConsumeSignalTo.Convert(pulsation.Push, software.Push);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Push> Push { get; }
        }
    }
}
