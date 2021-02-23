using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCorrectionSystem :
        IHardware<IPoseTrackerHardwareHandler>
    {
        private readonly IConnection<Position> position;

        private readonly IConnection<Rotation> rotation;

        public PoseTrackerCorrectionSystem(IPoseTrackerSoftwareHandler handler, IPoseTrackerCalculation calculation, IPoseTrackerConfiguration configuration)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (calculation == null)
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            position = handler.Position.Correct(calculation.Position, configuration.Position);

            rotation = handler.Rotation.Correct(calculation.Rotation, configuration.Rotation);
        }

        public IDisconnection Connect(IPoseTrackerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var position = this.position.Connect(handler.Position);

            var rotation = this.rotation.Connect(handler.Rotation);

            return new Disconnection(() =>
            {
                position.Disconnect();

                rotation.Disconnect();
            });
        }
    }
}
