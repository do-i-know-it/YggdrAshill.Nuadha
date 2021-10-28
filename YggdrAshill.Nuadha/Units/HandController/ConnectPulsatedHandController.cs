using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedHandController :
        IConnection<IPulsatedHandControllerSoftware>
    {
        private readonly ConnectPulsatedStick thumb;

        private readonly ConnectPulsatedTrigger indexFinger;

        private readonly ConnectPulsatedTrigger handGrip;

        internal ConnectPulsatedHandController(IHandControllerHardware module, HandControllerThreshold threshold)
        {
            thumb = new ConnectPulsatedStick(module.Thumb, threshold.Thumb);

            indexFinger = new ConnectPulsatedTrigger(module.IndexFinger, threshold.IndexFinger);

            handGrip = new ConnectPulsatedTrigger(module.HandGrip, threshold.HandGrip);
        }

        /// <inheritdoc/>
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
