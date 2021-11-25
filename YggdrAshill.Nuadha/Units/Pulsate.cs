using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations to pulsate units.
    /// </summary>
    public static class Pulsate
    {
        private static readonly ITranslation<Touch, Pulse> touch = PulseFrom.Signal(TouchIs.Enabled);

        private static readonly ITranslation<Push, Pulse> push = PulseFrom.Signal(PushIs.Enabled);

        /// <summary>
        /// Default <see cref="IButtonPulsation"/>.
        /// </summary>
        public static IButtonPulsation Button { get; } = new ButtonPulsation();
        private sealed class ButtonPulsation :
            IButtonPulsation
        {
            public ITranslation<Touch, Pulse> Touch => touch;

            public ITranslation<Push, Pulse> Push => push;
        }

        /// <summary>
        /// Default <see cref="ITriggerPulsation"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to pulsate.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerPulsation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITriggerPulsation Trigger(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TriggerPulsation(threshold);
        }
        private sealed class TriggerPulsation :
            ITriggerPulsation
        {
            internal TriggerPulsation(HysteresisThreshold threshold)
            {
                Pull = PulseFrom.Signal(PullIs.Over(threshold));
            }

            public ITranslation<Touch, Pulse> Touch => touch;

            public ITranslation<Pull, Pulse> Pull { get; }
        }

        /// <summary>
        /// Default <see cref="ITiltPulsation"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to pulsate.
        /// </param>
        /// <returns>
        /// <see cref="ITiltPulsation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITiltPulsation Tilt(TiltThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new TiltPulsation(threshold);
        }
        private sealed class TiltPulsation :
            ITiltPulsation
        {
            internal TiltPulsation(TiltThreshold threshold)
            {
                Distance
                    = TiltIntoPullBy.Distance
                    .Then(PulseFrom.Signal(PullIs.Over(threshold.Distance)));

                Left
                    = TiltIntoPullBy.Left
                    .Then(PulseFrom.Signal(PullIs.Over(threshold.Left)));

                Right
                    = TiltIntoPullBy.Right
                    .Then(PulseFrom.Signal(PullIs.Over(threshold.Right)));

                Forward
                    = TiltIntoPullBy.Forward
                    .Then(PulseFrom.Signal(PullIs.Over(threshold.Forward)));

                Backward
                    = TiltIntoPullBy.Backward
                    .Then(PulseFrom.Signal(PullIs.Over(threshold.Backward)));
            }

            public ITranslation<Tilt, Pulse> Distance { get; }

            public ITranslation<Tilt, Pulse> Left { get; }

            public ITranslation<Tilt, Pulse> Right { get; }

            public ITranslation<Tilt, Pulse> Forward { get; }

            public ITranslation<Tilt, Pulse> Backward { get; }
        }

        /// <summary>
        /// Default <see cref="IStickPulsation"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to pulsate.
        /// </param>
        /// <returns>
        /// <see cref="IStickPulsation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IStickPulsation Stick(TiltThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new StickPulsation(threshold);
        }
        private sealed class StickPulsation :
            IStickPulsation
        {
            internal StickPulsation(TiltThreshold threshold)
            {
                Touch = Button.Touch;

                Tilt = Tilt(threshold);
            }

            public ITranslation<Touch, Pulse> Touch { get; }

            public ITiltPulsation Tilt { get; }
        }

        /// <summary>
        /// Default <see cref="IHandControllerPulsation"/>.
        /// </summary>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to pulsate.
        /// </param>
        /// <returns>
        /// <see cref="IHandControllerPulsation"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IHandControllerPulsation HandController(HandControllerThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new HandControllerPulsation(threshold);
        }
        private sealed class HandControllerPulsation :
            IHandControllerPulsation
        {
            internal HandControllerPulsation(HandControllerThreshold threshold)
            {
                Thumb = Stick(threshold.Thumb);

                IndexFinger = Trigger(threshold.IndexFinger);

                HandGrip = Trigger(threshold.HandGrip);
            }

            public IStickPulsation Thumb { get; }

            public ITriggerPulsation IndexFinger { get; }

            public ITriggerPulsation HandGrip { get; }
        }
    }
}
