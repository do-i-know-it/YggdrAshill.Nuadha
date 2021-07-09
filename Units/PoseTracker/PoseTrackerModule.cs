using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public abstract class PoseTrackerModule :
        IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler>,
        IPoseTrackerSoftwareHandler,
        IPoseTrackerHardwareHandler
    {
        private readonly IPropagation<Space3D.Position> position;

        private readonly IPropagation<Space3D.Rotation> rotation;

        protected PoseTrackerModule(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            if (rotation == null)
            {
                throw new ArgumentNullException(nameof(rotation));
            }

            this.position = position;

            this.rotation = rotation;
        }

        public IPoseTrackerHardwareHandler HardwareHandler => this;

        public IPoseTrackerSoftwareHandler SoftwareHandler => this;

        public virtual void Dispose()
        {
            position.Dispose();

            rotation.Dispose();
        }

        IConsumption<Space3D.Position> IPoseTrackerHardwareHandler.Position => position;

        IConsumption<Space3D.Rotation> IPoseTrackerHardwareHandler.Rotation => rotation;

        IProduction<Space3D.Position> IPoseTrackerSoftwareHandler.Position => position;

        IProduction<Space3D.Rotation> IPoseTrackerSoftwareHandler.Rotation => rotation;
    }
}
