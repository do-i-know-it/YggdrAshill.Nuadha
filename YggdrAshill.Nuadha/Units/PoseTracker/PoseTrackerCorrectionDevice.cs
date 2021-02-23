using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCorrectionDevice :
        IHardware<IPoseTrackerSystem>
    {
        private readonly IConnection<Position> position;

        private readonly IConnection<Rotation> rotation;

        public PoseTrackerCorrectionDevice(IPoseTrackerDevice device, IPoseTrackerCalculation calculation, IPoseTrackerConfiguration configuration)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            position = device.Position.Correct(calculation.Position, configuration.Position);

            rotation = device.Rotation.Correct(calculation.Rotation, configuration.Rotation);
        }

        public IDisconnection Connect(IPoseTrackerSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var position = this.position.Connect(system.Position);

            var rotation = this.rotation.Connect(system.Rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }
    }
}
