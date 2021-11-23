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

        public static IButtonPulsation Button { get; } = new ButtonPulsation();
        private sealed class ButtonPulsation :
            IButtonPulsation
        {
            public ITranslation<Touch, Pulse> Touch => touch;

            public ITranslation<Push, Pulse> Push => push;
        }

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
                Pull = PulseFrom.Signal(PullIs.Enabled(threshold));
            }

            public ITranslation<Touch, Pulse> Touch => touch;

            public ITranslation<Pull, Pulse> Pull { get; }
        }

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
                    = TiltInto.PullBy.Distance
                    .Then(PulseFrom.Signal(PullIs.Enabled(threshold.Distance)));

                Left
                    = TiltInto.PullBy.Left
                    .Then(PulseFrom.Signal(PullIs.Enabled(threshold.Left)));

                Right
                    = TiltInto.PullBy.Right
                    .Then(PulseFrom.Signal(PullIs.Enabled(threshold.Right)));

                Forward
                    = TiltInto.PullBy.Forward
                    .Then(PulseFrom.Signal(PullIs.Enabled(threshold.Forward)));

                Backward
                    = TiltInto.PullBy.Backward
                    .Then(PulseFrom.Signal(PullIs.Enabled(threshold.Backward)));
            }

            public ITranslation<Tilt, Pulse> Distance { get; }

            public ITranslation<Tilt, Pulse> Left { get; }

            public ITranslation<Tilt, Pulse> Right { get; }

            public ITranslation<Tilt, Pulse> Forward { get; }

            public ITranslation<Tilt, Pulse> Backward { get; }
        }

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
