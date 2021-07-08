using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;
using System;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public abstract class PoseTrackerModule :
        IModule<IPoseTrackerHardware, IPoseTrackerSoftware>,
        IPoseTrackerHardware,
        IPoseTrackerSoftware
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

        #region IModule

        public IPoseTrackerHardware Hardware => this;

        public IPoseTrackerSoftware Software => this;

        #endregion

        #region IDisposable

        public virtual void Dispose()
        {
            position.Dispose();

            rotation.Dispose();
        }

        #endregion

        #region IPoseTrackerHardware

        IProduction<Space3D.Position> IPoseTrackerHardware.Position => position;

        IProduction<Space3D.Rotation> IPoseTrackerHardware.Rotation => rotation;

        #endregion

        #region IPoseTrackerSoftware

        IConsumption<Space3D.Position> IPoseTrackerSoftware.Position => position;

        IConsumption<Space3D.Rotation> IPoseTrackerSoftware.Rotation => rotation;

        #endregion
    }
}
