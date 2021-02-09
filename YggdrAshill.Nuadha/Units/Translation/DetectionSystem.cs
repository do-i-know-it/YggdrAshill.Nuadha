using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class DetectionSystem<TSignal> :
        IConsumption<TSignal>,
        IHardware<IPulseDetectionInputHandler>,
        IDisconnection
        where TSignal : ISignal
    {
        protected abstract IPropagation<TSignal> Propagation { get; }
        protected abstract IDetection<TSignal> HasEnabled { get; }
        protected abstract IDetection<TSignal> IsEnabled { get; }
        protected abstract IDetection<TSignal> HasDisabled { get; }
        protected abstract IDetection<TSignal> IsDisabled { get; }

        public IDisconnection Connect(IPulseDetectionInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasEnabled = Propagation.Detect(HasEnabled).Connect(handler.HasEnabled);
            var isEnabled = Propagation.Detect(IsEnabled).Connect(handler.IsEnabled);
            var hasDisabled = Propagation.Detect(HasDisabled).Connect(handler.HasDisabled);
            var isDisabled = Propagation.Detect(IsDisabled).Connect(handler.IsDisabled);

            return new Disconnection(() =>
            {
                hasEnabled.Disconnect();

                isEnabled.Disconnect();

                hasDisabled.Disconnect();

                isDisabled.Disconnect();
            });
        }

        public void Consume(TSignal signal)
        {
            Propagation.Consume(signal);
        }

        public void Disconnect()
        {
            Propagation.Disconnect();
        }
    }
}
