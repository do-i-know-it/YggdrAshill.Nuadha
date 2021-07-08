using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HandControllerPulsationModule :
        IModule<IHandControllerPulsationHardware, IHandControllerPulsationSoftware>,
        IHandControllerPulsationHardware,
        IHandControllerPulsationSoftware
    {
        private readonly StickPulsationModule thumb;

        private readonly TriggerPulsationModule indexFinger;

        private readonly TriggerPulsationModule handGrip;

        public HandControllerPulsationModule(StickPulsationModule thumb, TriggerPulsationModule indexFinger, TriggerPulsationModule handGrip)
        {
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        #region IModule

        public IHandControllerPulsationHardware Hardware => this;

        public IHandControllerPulsationSoftware Software => this;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        #endregion

        #region IHandControllerPulsationHardware

        IStickPulsationHardware IHandControllerPulsationHardware.Thumb => thumb;

        ITriggerPulsationHardware IHandControllerPulsationHardware.IndexFinger => indexFinger;

        ITriggerPulsationHardware IHandControllerPulsationHardware.HandGrip => handGrip;

        #endregion

        #region IHandControllerPulsationSoftware

        IStickPulsationSoftware IHandControllerPulsationSoftware.Thumb => thumb;

        ITriggerPulsationSoftware IHandControllerPulsationSoftware.IndexFinger => indexFinger;

        ITriggerPulsationSoftware IHandControllerPulsationSoftware.HandGrip => handGrip;

        #endregion
    }
}
