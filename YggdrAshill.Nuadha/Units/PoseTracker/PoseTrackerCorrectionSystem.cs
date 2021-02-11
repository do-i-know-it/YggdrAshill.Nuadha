using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerCorrectionSystem :
        IHardware<IPoseTrackerHardwareHandler>
    {
        private readonly CorrectionSystem<Position> position;

        private readonly CorrectionSystem<Rotation> rotation;

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

            position = new CorrectionSystem<Position>(handler.Position, calculation.Position, configuration.Position);

            rotation = new CorrectionSystem<Rotation>(handler.Rotation, calculation.Rotation, configuration.Rotation);
        }

        #region IHardware

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

        #endregion
    }
}
