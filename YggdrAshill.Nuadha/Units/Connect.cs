using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class Connect
    {
        #region Button

        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IButtonHardware> Button(IButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectButtonHardware(software);
        }
        private sealed class ConnectButtonHardware :
            IConnection<IButtonHardware>
        {
            private readonly IButtonSoftware software;

            internal ConnectButtonHardware(IButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Push.Produce(software.Push).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IButtonSoftware> Button(IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectButtonSoftware(hardware);
        }
        private sealed class ConnectButtonSoftware :
            IConnection<IButtonSoftware>
        {
            private readonly IButtonHardware hardware;

            internal ConnectButtonSoftware(IButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Push.Produce(module.Push).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonHardware> PulsatedButton(IPulsatedButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedButtonHardware(software);
        }
        private sealed class ConnectPulsatedButtonHardware :
            IConnection<IPulsatedButtonHardware>
        {
            private readonly IPulsatedButtonSoftware software;

            internal ConnectPulsatedButtonHardware(IPulsatedButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Push.Produce(software.Push).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/> converted from <see cref="IPulsatedButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> PulsatedButton(IPulsatedButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedButtonSoftware(hardware);
        }
        private sealed class ConnectPulsatedButtonSoftware :
            IConnection<IPulsatedButtonSoftware>
        {
            private readonly IPulsatedButtonHardware hardware;

            internal ConnectPulsatedButtonSoftware(IPulsatedButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Push.Produce(module.Push).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region Trigger

        /// <summary>
        /// Converts <see cref="ITriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/> converted from <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<ITriggerHardware> Trigger(ITriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectTriggerHardware(software);
        }
        private sealed class ConnectTriggerHardware :
            IConnection<ITriggerHardware>
        {
            private readonly ITriggerSoftware software;

            internal ConnectTriggerHardware(ITriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(ITriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Pull.Produce(software.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<ITriggerSoftware> Trigger(ITriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectTriggerSoftware(hardware);
        }
        private sealed class ConnectTriggerSoftware :
            IConnection<ITriggerSoftware>
        {
            private readonly ITriggerHardware hardware;

            internal ConnectTriggerSoftware(ITriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(ITriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Pull.Produce(module.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerHardware> PulsatedTrigger(IPulsatedTriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedTriggerHardware(software);
        }
        private sealed class ConnectPulsatedTriggerHardware :
            IConnection<IPulsatedTriggerHardware>
        {
            private readonly IPulsatedTriggerSoftware software;

            internal ConnectPulsatedTriggerHardware(IPulsatedTriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Pull.Produce(software.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/> converted from <see cref="IPulsatedTriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> PulsatedTrigger(IPulsatedTriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedTriggerSoftware(hardware);
        }
        private sealed class ConnectPulsatedTriggerSoftware :
            IConnection<IPulsatedTriggerSoftware>
        {
            private readonly IPulsatedTriggerHardware hardware;

            internal ConnectPulsatedTriggerSoftware(IPulsatedTriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Pull.Produce(module.Pull).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region Tilt

        /// <summary>
        /// Converts <see cref="IPulsatedTiltSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltHardware"/> converted from <see cref="IPulsatedTiltSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltHardware> PulsatedTilt(IPulsatedTiltSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedTiltHardware(software);
        }
        private sealed class ConnectPulsatedTiltHardware :
            IConnection<IPulsatedTiltHardware>
        {
            private readonly IPulsatedTiltSoftware software;

            internal ConnectPulsatedTiltHardware(IPulsatedTiltSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedTiltHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Distance.Produce(software.Distance).Synthesize(composite);
                module.Left.Produce(software.Left).Synthesize(composite);
                module.Right.Produce(software.Right).Synthesize(composite);
                module.Forward.Produce(software.Forward).Synthesize(composite);
                module.Backward.Produce(software.Backward).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTiltHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTiltHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltSoftware> PulsatedTilt(IPulsatedTiltHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedTiltSoftware(hardware);
        }
        private sealed class ConnectPulsatedTiltSoftware :
            IConnection<IPulsatedTiltSoftware>
        {
            private readonly IPulsatedTiltHardware hardware;

            internal ConnectPulsatedTiltSoftware(IPulsatedTiltHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedTiltSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Distance.Produce(module.Distance).Synthesize(composite);
                hardware.Left.Produce(module.Left).Synthesize(composite);
                hardware.Right.Produce(module.Right).Synthesize(composite);
                hardware.Forward.Produce(module.Forward).Synthesize(composite);
                hardware.Backward.Produce(module.Backward).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region Stick

        /// <summary>
        /// Converts <see cref="IStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/> converted from <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IStickHardware> Stick(IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectStickHardware(software);
        }
        private sealed class ConnectStickHardware :
            IConnection<IStickHardware>
        {
            private readonly IStickSoftware software;

            internal ConnectStickHardware(IStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Tilt.Produce(software.Tilt).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IStickSoftware> Stick(IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectStickSoftware(hardware);
        }
        private sealed class ConnectStickSoftware :
            IConnection<IStickSoftware>
        {
            private readonly IStickHardware hardware;

            internal ConnectStickSoftware(IStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Tilt.Produce(module.Tilt).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/> converted from <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickHardware> PulsatedStick(IPulsatedStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedStickHardware(software);
        }
        private sealed class ConnectPulsatedStickHardware :
            IConnection<IPulsatedStickHardware>
        {
            private readonly IPulsatedStickSoftware software;

            internal ConnectPulsatedStickHardware(IPulsatedStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Tilt.Distance.Produce(software.Tilt.Distance).Synthesize(composite);
                module.Tilt.Left.Produce(software.Tilt.Left).Synthesize(composite);
                module.Tilt.Right.Produce(software.Tilt.Right).Synthesize(composite);
                module.Tilt.Forward.Produce(software.Tilt.Forward).Synthesize(composite);
                module.Tilt.Backward.Produce(software.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/> converted from <see cref="IPulsatedStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickSoftware> PulsatedStick(IPulsatedStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedStickSoftware(hardware);
        }
        private sealed class ConnectPulsatedStickSoftware :
            IConnection<IPulsatedStickSoftware>
        {
            private readonly IPulsatedStickHardware hardware;

            internal ConnectPulsatedStickSoftware(IPulsatedStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Tilt.Distance.Produce(module.Tilt.Distance).Synthesize(composite);
                hardware.Tilt.Left.Produce(module.Tilt.Left).Synthesize(composite);
                hardware.Tilt.Right.Produce(module.Tilt.Right).Synthesize(composite);
                hardware.Tilt.Forward.Produce(module.Tilt.Forward).Synthesize(composite);
                hardware.Tilt.Backward.Produce(module.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region PoseTracker

        /// <summary>
        /// Converts <see cref="IPoseTrackerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPoseTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerHardware"/> converted from <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerHardware> PoseTracker(IPoseTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPoseTrackerHardware(software);
        }
        private sealed class ConnectPoseTrackerHardware :
            IConnection<IPoseTrackerHardware>
        {
            private readonly IPoseTrackerSoftware software;

            internal ConnectPoseTrackerHardware(IPoseTrackerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPoseTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Position.Produce(software.Position).Synthesize(composite);
                module.Rotation.Produce(software.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPoseTrackerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerSoftware> PoseTracker(IPoseTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPoseTrackerSoftware(hardware);
        }
        private sealed class ConnectPoseTrackerSoftware :
            IConnection<IPoseTrackerSoftware>
        {
            private readonly IPoseTrackerHardware hardware;

            internal ConnectPoseTrackerSoftware(IPoseTrackerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Position.Produce(module.Position).Synthesize(composite);
                hardware.Rotation.Produce(module.Rotation).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region HeadTracker

        /// <summary>
        /// Converts <see cref="IHeadTrackerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHeadTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerHardware"/> converted from <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHeadTrackerHardware> HeadTracker(IHeadTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHeadTrackerHardware(software);
        }
        private sealed class ConnectHeadTrackerHardware :
            IConnection<IHeadTrackerHardware>
        {
            private readonly IHeadTrackerSoftware software;

            internal ConnectHeadTrackerHardware(IHeadTrackerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHeadTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Pose.Position.Produce(software.Pose.Position).Synthesize(composite);
                module.Pose.Rotation.Produce(software.Pose.Rotation).Synthesize(composite);
                module.Direction.Produce(software.Direction).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHeadTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHeadTrackerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/> converted from <see cref="IHeadTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHeadTrackerSoftware> HeadTracker(IHeadTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectHeadTrackerSoftware(hardware);
        }
        private sealed class ConnectHeadTrackerSoftware :
            IConnection<IHeadTrackerSoftware>
        {
            private readonly IHeadTrackerHardware hardware;

            internal ConnectHeadTrackerSoftware(IHeadTrackerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Pose.Position.Produce(module.Pose.Position).Synthesize(composite);
                hardware.Pose.Rotation.Produce(module.Pose.Rotation).Synthesize(composite);
                hardware.Direction.Produce(module.Direction).Synthesize(composite);

                return composite;
            }
        }

        #endregion

        #region HandController

        /// <summary>
        /// Converts <see cref="IHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/> converted from <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHandControllerHardware> HandController(IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHandControllerHardware(software);
        }
        private sealed class ConnectHandControllerHardware :
            IConnection<IHandControllerHardware>
        {
            private readonly IHandControllerSoftware software;

            internal ConnectHandControllerHardware(IHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.HandGrip.Touch.Produce(software.HandGrip.Touch).Synthesize(composite);
                module.HandGrip.Pull.Produce(software.HandGrip.Pull).Synthesize(composite);

                module.IndexFinger.Touch.Produce(software.IndexFinger.Touch).Synthesize(composite);
                module.IndexFinger.Pull.Produce(software.IndexFinger.Pull).Synthesize(composite);

                module.Thumb.Touch.Produce(software.Thumb.Touch).Synthesize(composite);
                module.Thumb.Tilt.Produce(software.Thumb.Tilt).Synthesize(composite);

                module.Pose.Position.Produce(software.Pose.Position).Synthesize(composite);
                module.Pose.Rotation.Produce(software.Pose.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHandControllerSoftware> HandController(IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectHandControllerSoftware(hardware);
        }
        private sealed class ConnectHandControllerSoftware :
            IConnection<IHandControllerSoftware>
        {
            private readonly IHandControllerHardware hardware;

            internal ConnectHandControllerSoftware(IHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.HandGrip.Touch.Produce(module.HandGrip.Touch).Synthesize(composite);
                hardware.HandGrip.Pull.Produce(module.HandGrip.Pull).Synthesize(composite);

                hardware.IndexFinger.Touch.Produce(module.IndexFinger.Touch).Synthesize(composite);
                hardware.IndexFinger.Pull.Produce(module.IndexFinger.Pull).Synthesize(composite);

                hardware.Thumb.Touch.Produce(module.Thumb.Touch).Synthesize(composite);
                hardware.Thumb.Tilt.Produce(module.Thumb.Tilt).Synthesize(composite);

                hardware.Pose.Position.Produce(module.Pose.Position).Synthesize(composite);
                hardware.Pose.Rotation.Produce(module.Pose.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IPulsatedHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerHardware> PulsatedHandController(IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPulsatedHandControllerHardware(software);
        }
        private sealed class ConnectPulsatedHandControllerHardware :
            IConnection<IPulsatedHandControllerHardware>
        {
            private readonly IPulsatedHandControllerSoftware software;

            internal ConnectPulsatedHandControllerHardware(IPulsatedHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPulsatedHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.IndexFinger.Touch.Produce(software.IndexFinger.Touch).Synthesize(composite);
                module.IndexFinger.Pull.Produce(software.IndexFinger.Pull).Synthesize(composite);

                module.HandGrip.Touch.Produce(software.HandGrip.Touch).Synthesize(composite);
                module.HandGrip.Pull.Produce(software.HandGrip.Pull).Synthesize(composite);

                module.Thumb.Touch.Produce(software.Thumb.Touch).Synthesize(composite);
                module.Thumb.Tilt.Distance.Produce(software.Thumb.Tilt.Distance).Synthesize(composite);
                module.Thumb.Tilt.Left.Produce(software.Thumb.Tilt.Left).Synthesize(composite);
                module.Thumb.Tilt.Right.Produce(software.Thumb.Tilt.Right).Synthesize(composite);
                module.Thumb.Tilt.Forward.Produce(software.Thumb.Tilt.Forward).Synthesize(composite);
                module.Thumb.Tilt.Backward.Produce(software.Thumb.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IPulsatedHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerSoftware> PulsatedHandController(IPulsatedHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPulsatedHandControllerSoftware(hardware);
        }
        private sealed class ConnectPulsatedHandControllerSoftware :
            IConnection<IPulsatedHandControllerSoftware>
        {
            private readonly IPulsatedHandControllerHardware hardware;

            internal ConnectPulsatedHandControllerSoftware(IPulsatedHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPulsatedHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.IndexFinger.Touch.Produce(module.IndexFinger.Touch).Synthesize(composite);
                hardware.IndexFinger.Pull.Produce(module.IndexFinger.Pull).Synthesize(composite);

                hardware.HandGrip.Touch.Produce(module.HandGrip.Touch).Synthesize(composite);
                hardware.HandGrip.Pull.Produce(module.HandGrip.Pull).Synthesize(composite);

                hardware.Thumb.Touch.Produce(module.Thumb.Touch).Synthesize(composite);
                hardware.Thumb.Tilt.Distance.Produce(module.Thumb.Tilt.Distance).Synthesize(composite);
                hardware.Thumb.Tilt.Left.Produce(module.Thumb.Tilt.Left).Synthesize(composite);
                hardware.Thumb.Tilt.Right.Produce(module.Thumb.Tilt.Right).Synthesize(composite);
                hardware.Thumb.Tilt.Forward.Produce(module.Thumb.Tilt.Forward).Synthesize(composite);
                hardware.Thumb.Tilt.Backward.Produce(module.Thumb.Tilt.Backward).Synthesize(composite);

                return composite;
            }
        }

        #endregion
    }
}
