using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class DetectionDevice<TSignal> :
        IHardware<IDetectionSystem>
        where TSignal : ISignal
    {
        protected abstract IConnection<TSignal> Connection { get; }
        protected abstract IDetection<TSignal> HasEnabled { get; }
        protected abstract IDetection<TSignal> IsEnabled { get; }
        protected abstract IDetection<TSignal> HasDisabled { get; }
        protected abstract IDetection<TSignal> IsDisabled { get; }

        public IDisconnection Connect(IDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var hasEnabled = Connection.Detect(HasEnabled).Connect(system.HasEnabled);
            var isEnabled = Connection.Detect(IsEnabled).Connect(system.IsEnabled);
            var hasDisabled = Connection.Detect(HasDisabled).Connect(system.HasDisabled);
            var isDisabled = Connection.Detect(IsDisabled).Connect(system.IsDisabled);

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
