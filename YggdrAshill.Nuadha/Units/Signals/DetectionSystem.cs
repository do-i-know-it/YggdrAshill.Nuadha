using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class DetectionSystem<TSignal> :
        IHardware<IDetectionHardwareHandler>
        where TSignal : ISignal
    {
        protected abstract IConnection<TSignal> Connection { get; }
        protected abstract IDetection<TSignal> HasEnabled { get; }
        protected abstract IDetection<TSignal> IsEnabled { get; }
        protected abstract IDetection<TSignal> HasDisabled { get; }
        protected abstract IDetection<TSignal> IsDisabled { get; }

        public IDisconnection Connect(IDetectionHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var hasEnabled = Connection.Detect(HasEnabled).Connect(handler.HasEnabled);
            var isEnabled = Connection.Detect(IsEnabled).Connect(handler.IsEnabled);
            var hasDisabled = Connection.Detect(HasDisabled).Connect(handler.HasDisabled);
            var isDisabled = Connection.Detect(IsDisabled).Connect(handler.IsDisabled);

            return new Disconnection(() =>
            {
                hasEnabled.Disconnect();

                isEnabled.Disconnect();

                hasDisabled.Disconnect();

                isDisabled.Disconnect();
            });
        }
    }
}
