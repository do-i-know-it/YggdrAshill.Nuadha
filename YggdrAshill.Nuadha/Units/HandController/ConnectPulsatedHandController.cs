using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPulsatedHandController
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
        public static IConnection<IPulsatedHandControllerHardware> Hardware(this IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPulsatedHandControllerHardware>
        {
            private readonly IPulsatedHandControllerSoftware software;

            internal ConnectHardware(IPulsatedHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.IndexFinger.Touch.Produce(software.IndexFinger.Touch).Synthesize(composite);
                module.IndexFinger.Pull.Produce(software.IndexFinger.Pull).Synthesize(composite);

                module.HandGrip.Touch.Produce(software.HandGrip.Touch).Synthesize(composite);
                module.HandGrip.Pull.Produce(software.HandGrip.Pull).Synthesize(composite);

                module.Thumb.Touch.Produce(software.Thumb.Touch).Synthesize(composite);
                module.Thumb.Tilt.Distance.Produce(software.Thumb.Tilt.Distance).Synthesize(composite);
                module.Thumb.Tilt.Left.Produce(software.Thumb.Tilt.Left).Synthesize(composite);
                module.Thumb.Tilt.Right.Produce(software.Thumb.Tilt.Right).Synthesize(composite);
                module.Thumb.Tilt.Forward.Produce(software.Thumb.Tilt.Forward).Synthesize(composite);
                module.Thumb.Tilt.Backward.Produce(software.Thumb.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IPulsatedHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerSoftware> Connect(this IPulsatedHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPulsatedHandControllerSoftware>
        {
            private readonly IPulsatedHandControllerHardware hardware;

            internal ConnectSoftware(IPulsatedHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.IndexFinger.Touch.Produce(module.IndexFinger.Touch).Synthesize(composite);
                hardware.IndexFinger.Pull.Produce(module.IndexFinger.Pull).Synthesize(composite);

                hardware.HandGrip.Touch.Produce(module.HandGrip.Touch).Synthesize(composite);
                hardware.HandGrip.Pull.Produce(module.HandGrip.Pull).Synthesize(composite);

                hardware.Thumb.Touch.Produce(module.Thumb.Touch).Synthesize(composite);
                hardware.Thumb.Tilt.Distance.Produce(module.Thumb.Tilt.Distance).Synthesize(composite);
                hardware.Thumb.Tilt.Left.Produce(module.Thumb.Tilt.Left).Synthesize(composite);
                hardware.Thumb.Tilt.Right.Produce(module.Thumb.Tilt.Right).Synthesize(composite);
                hardware.Thumb.Tilt.Forward.Produce(module.Thumb.Tilt.Forward).Synthesize(composite);
                hardware.Thumb.Tilt.Backward.Produce(module.Thumb.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }
    }
}
