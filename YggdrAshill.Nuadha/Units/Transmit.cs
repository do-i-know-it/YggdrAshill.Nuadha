using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class Transmit
    {
        public static ITransmission<IButtonSoftware> Button(IButtonConfiguration configuration, IButtonProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitButton(configuration, protocol);
        }
        private sealed class TransmitButton :
            ITransmission<IButtonSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IButtonSoftware> connection;

            internal TransmitButton(IButtonConfiguration configuration, IButtonProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(IButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }

        public static ITransmission<ITriggerSoftware> Trigger(ITriggerConfiguration configuration, ITriggerProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitTrigger(configuration, protocol);
        }
        private sealed class TransmitTrigger :
            ITransmission<ITriggerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<ITriggerSoftware> connection;

            internal TransmitTrigger(ITriggerConfiguration configuration, ITriggerProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(ITriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }

        public static ITransmission<IStickSoftware> Stick(IStickConfiguration configuration, IStickProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitStick(configuration, protocol);
        }
        private sealed class TransmitStick :
            ITransmission<IStickSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IStickSoftware> connection;

            internal TransmitStick(IStickConfiguration configuration, IStickProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }

        public static ITransmission<IPoseTrackerSoftware> PoseTracker(IPoseTrackerConfiguration configuration, IPoseTrackerProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitPoseTracker(configuration, protocol);
        }
        private sealed class TransmitPoseTracker :
            ITransmission<IPoseTrackerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IPoseTrackerSoftware> connection;

            internal TransmitPoseTracker(IPoseTrackerConfiguration configuration, IPoseTrackerProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }

        public static ITransmission<IHeadTrackerSoftware> HeadTracker(IHeadTrackerConfiguration configuration, IHeadTrackerProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitHeadTracker(configuration, protocol);
        }
        private sealed class TransmitHeadTracker :
            ITransmission<IHeadTrackerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IHeadTrackerSoftware> connection;

            internal TransmitHeadTracker(IHeadTrackerConfiguration configuration, IHeadTrackerProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }

        public static ITransmission<IHandControllerSoftware> HandController(IHandControllerConfiguration configuration, IHandControllerProtocol protocol)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return new TransmitHandController(configuration, protocol);
        }
        private sealed class TransmitHandController :
            ITransmission<IHandControllerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IHandControllerSoftware> connection;

            internal TransmitHandController(IHandControllerConfiguration configuration, IHandControllerProtocol protocol)
            {
                emission = protocol.Software.Conduct(configuration);

                connection = protocol.Hardware.Connect();
            }

            public ICancellation Connect(IHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }
    }
}
