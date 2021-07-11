using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class ConnectPulsatedHandController :
        IConnection<IPulsatedHandControllerHardwareHandler>
    {
        private readonly ConnectPulsatedStick thumb;

        private readonly ConnectPulsatedTrigger indexFinger;

        private readonly ConnectPulsatedTrigger handGrip;

        internal ConnectPulsatedHandController(IHandControllerSoftwareHandler handler, HandControllerThreshold threshold)
        {
            thumb = new ConnectPulsatedStick(handler.Thumb, threshold.Thumb);

            indexFinger = new ConnectPulsatedTrigger(handler.IndexFinger, threshold.IndexFinger);

            handGrip = new ConnectPulsatedTrigger(handler.HandGrip, threshold.HandGrip);
        }

        /// <inheritdoc/>
        public ICancellation Connect(IPulsatedHandControllerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            thumb.Connect(handler.Thumb).Synthesize(synthesized);
            indexFinger.Connect(handler.IndexFinger).Synthesize(synthesized);
            handGrip.Connect(handler.HandGrip).Synthesize(synthesized);

            return synthesized;
        }
    }
}
