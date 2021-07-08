using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class StickModule :
        IModule<IStickHardware, IStickSoftware>,
        IStickHardware,
        IStickSoftware
    {
        private readonly IPropagation<Touch> touch;

        private readonly IPropagation<Tilt> tilt;

        public StickModule(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (tilt == null)
            {
                throw new ArgumentNullException(nameof(tilt));
            }

            this.touch = touch;

            this.tilt = tilt;
        }

        #region IModule

        public IStickHardware Hardware => this;

        public IStickSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        #endregion

        #region IStickHardware

        IProduction<Touch> IStickHardware.Touch => touch;

        IProduction<Tilt> IStickHardware.Tilt => tilt;

        #endregion

        #region IStickSoftware

        IConsumption<Touch> IStickSoftware.Touch => touch;

        IConsumption<Tilt> IStickSoftware.Tilt => tilt;

        #endregion
    }
}
