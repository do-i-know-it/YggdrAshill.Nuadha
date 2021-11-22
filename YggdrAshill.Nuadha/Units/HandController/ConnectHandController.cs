using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectHandController
    {
        /// <summary>
        /// Converts <see cref="IHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/> converted from <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHandControllerHardware> Connect(IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IHandControllerHardware>
        {
            private readonly IHandControllerSoftware software;

            internal ConnectHardware(IHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHandControllerHardware module)
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
                module.Thumb.Tilt.Produce(software.Thumb.Tilt).Synthesize(composite);

                module.Pose.Position.Produce(software.Pose.Position).Synthesize(composite);
                module.Pose.Rotation.Produce(software.Pose.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHandControllerSoftware> Connect(this IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IHandControllerSoftware>
        {
            private readonly IHandControllerHardware hardware;

            internal ConnectSoftware(IHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHandControllerSoftware module)
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
                hardware.Thumb.Tilt.Produce(module.Thumb.Tilt).Synthesize(composite);

                hardware.Pose.Position.Produce(module.Pose.Position).Synthesize(composite);
                hardware.Pose.Rotation.Produce(module.Pose.Rotation).Synthesize(composite);

                return composite;
            }
        }
    }
}
