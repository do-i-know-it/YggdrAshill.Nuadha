using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PoseTrackerModule :
        IPoseTrackerHardwareHandler,
        IPoseTrackerSoftwareHandler,
        IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler>
    {
        internal IPropagation<Space3D.Position> Position { get; }

        internal IPropagation<Space3D.Rotation> Rotation { get; }

        public PoseTrackerModule(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            if (rotation == null)
            {
                throw new ArgumentNullException(nameof(rotation));
            }

            Position = position;

            Rotation = rotation;
        }

        public IPoseTrackerHardwareHandler HardwareHandler => this;

        public IPoseTrackerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Position.Dispose();

            Rotation.Dispose();
        }

        IConsumption<Space3D.Position> IPoseTrackerHardwareHandler.Position => Position;

        IConsumption<Space3D.Rotation> IPoseTrackerHardwareHandler.Rotation => Rotation;

        IProduction<Space3D.Position> IPoseTrackerSoftwareHandler.Position => Position;

        IProduction<Space3D.Rotation> IPoseTrackerSoftwareHandler.Rotation => Rotation;
    }
}
