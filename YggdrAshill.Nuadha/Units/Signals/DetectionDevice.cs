using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public abstract class DetectionDevice<TSignal> :
        IDevice<IDetectionSoftware>
        where TSignal : ISignal
    {
        protected abstract IConnection<TSignal> Connection { get; }
        protected abstract IDetection<TSignal> HasEnabled { get; }
        protected abstract IDetection<TSignal> IsEnabled { get; }
        protected abstract IDetection<TSignal> HasDisabled { get; }
        protected abstract IDetection<TSignal> IsDisabled { get; }

        public IDisconnection Connect(IDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var hasEnabled = Connection.Detect(HasEnabled).Connect(software.HasEnabled);
            var isEnabled = Connection.Detect(IsEnabled).Connect(software.IsEnabled);
            var hasDisabled = Connection.Detect(HasDisabled).Connect(software.HasDisabled);
            var isDisabled = Connection.Detect(IsDisabled).Connect(software.IsDisabled);

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
