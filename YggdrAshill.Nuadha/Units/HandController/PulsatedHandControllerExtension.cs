using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedHandControllerHardware"/> and <see cref="IPulsatedHandControllerSoftware"/>.
    /// </summary>
    public static class PulsatedHandControllerExtension
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
        public static IConnection<IPulsatedHandControllerHardware> Connect(this IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedHandControllerHardware(software);
        }
        private sealed class ConnectPulsatedHandControllerHardware :
            IConnection<IPulsatedHandControllerHardware>
        {
            private readonly IConnection<IPulsatedStickHardware> thumb;

            private readonly IConnection<IPulsatedTriggerHardware> indexFinger;

            private readonly IConnection<IPulsatedTriggerHardware> handGrip;

            internal ConnectPulsatedHandControllerHardware(IPulsatedHandControllerSoftware software)
            {
                thumb = software.Thumb.Connect();

                indexFinger = software.IndexFinger.Connect();

                handGrip = software.HandGrip.Connect();
            }

            public ICancellation Connect(IPulsatedHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

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

            return new ConnectPulsatedHandControllerSoftware(hardware);
        }
        private sealed class ConnectPulsatedHandControllerSoftware :
            IConnection<IPulsatedHandControllerSoftware>
        {
            private readonly IConnection<IPulsatedStickSoftware> thumb;

            private readonly IConnection<IPulsatedTriggerSoftware> indexFinger;

            private readonly IConnection<IPulsatedTriggerSoftware> handGrip;

            internal ConnectPulsatedHandControllerSoftware(IPulsatedHandControllerHardware hardware)
            {
                thumb = hardware.Thumb.Connect();

                indexFinger = hardware.IndexFinger.Connect();

                handGrip = hardware.HandGrip.Connect();
            }

            public ICancellation Connect(IPulsatedHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                thumb.Connect(module.Thumb).Synthesize(composite);
                indexFinger.Connect(module.IndexFinger).Synthesize(composite);
                handGrip.Connect(module.HandGrip).Synthesize(composite);

                return composite;
            }
        }
    }
}
