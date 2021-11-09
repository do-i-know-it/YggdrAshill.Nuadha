using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TiltInto))]
    internal class TiltIntoSpecification
    {
        [Test]
        public void ShouldConvertTiltIntoPull()
        {
            // Distance
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Distance.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Backward));

            // Left
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Left.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Backward));

            // Right
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Right.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Backward));

            // Forward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Forward.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Backward));

            // Backward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Forward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Backward.Translate(Tilt.Backward));
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertTiltIntoPush(float threshold)
        {
            // Distance
            var distance = TiltInto.PushBy.Distance(new HysteresisThreshold(threshold));
            Assert.AreEqual(Push.Disabled, distance.Translate(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, distance.Translate(Tilt.Left));
            Assert.AreEqual(Push.Enabled, distance.Translate(Tilt.Right));
            Assert.AreEqual(Push.Enabled, distance.Translate(Tilt.Forward));
            Assert.AreEqual(Push.Enabled, distance.Translate(Tilt.Backward));

            // Left
            var left = TiltInto.PushBy.Left(new HysteresisThreshold(threshold));
            Assert.AreEqual(Push.Disabled, left.Translate(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, left.Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, left.Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, left.Translate(Tilt.Forward));
            Assert.AreEqual(Push.Disabled, left.Translate(Tilt.Backward));

            // Right
            var right = TiltInto.PushBy.Right(new HysteresisThreshold(threshold));
            Assert.AreEqual(Push.Disabled, right.Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, right.Translate(Tilt.Left));
            Assert.AreEqual(Push.Enabled, right.Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, right.Translate(Tilt.Forward));
            Assert.AreEqual(Push.Disabled, right.Translate(Tilt.Backward));

            // Forward
            var forward = TiltInto.PushBy.Forward(new HysteresisThreshold(threshold));
            Assert.AreEqual(Push.Disabled, forward.Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, forward.Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, forward.Translate(Tilt.Right));
            Assert.AreEqual(Push.Enabled, forward.Translate(Tilt.Forward));
            Assert.AreEqual(Push.Disabled, forward.Translate(Tilt.Backward));

            // Backward
            var backward = TiltInto.PushBy.Backward(new HysteresisThreshold(threshold));
            Assert.AreEqual(Push.Disabled, backward.Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, backward.Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, backward.Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, backward.Translate(Tilt.Forward));
            Assert.AreEqual(Push.Enabled, backward.Translate(Tilt.Backward));
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertTiltIntoPulse(float threshold)
        {
            // Distance
            var distance = TiltInto.PulseBy.Distance(new HysteresisThreshold(threshold));
            Assert.AreEqual(Pulse.IsDisabled, distance.Translate(Tilt.Origin));
            Assert.AreEqual(Pulse.HasEnabled, distance.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.IsEnabled, distance.Translate(Tilt.Right));
            Assert.AreEqual(Pulse.HasDisabled, distance.Translate(Tilt.Origin));
            Assert.AreEqual(Pulse.HasEnabled, distance.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.IsEnabled, distance.Translate(Tilt.Backward));
            Assert.AreEqual(Pulse.HasDisabled, distance.Translate(Tilt.Origin));
            Assert.AreEqual(Pulse.IsDisabled, distance.Translate(Tilt.Origin));

            // Left
            var left = TiltInto.PulseBy.Left(new HysteresisThreshold(threshold));
            Assert.AreEqual(Pulse.IsDisabled, left.Translate(Tilt.Right));
            Assert.AreEqual(Pulse.HasEnabled, left.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.IsEnabled, left.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.HasDisabled, left.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.IsDisabled, left.Translate(Tilt.Backward));

            // Right
            var right = TiltInto.PulseBy.Right(new HysteresisThreshold(threshold));
            Assert.AreEqual(Pulse.IsDisabled, right.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.HasEnabled, right.Translate(Tilt.Right));
            Assert.AreEqual(Pulse.IsEnabled, right.Translate(Tilt.Right));
            Assert.AreEqual(Pulse.HasDisabled, right.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.IsDisabled, right.Translate(Tilt.Backward));

            // Forward
            var forward = TiltInto.PulseBy.Forward(new HysteresisThreshold(threshold));
            Assert.AreEqual(Pulse.IsDisabled, forward.Translate(Tilt.Backward));
            Assert.AreEqual(Pulse.HasEnabled, forward.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.IsEnabled, forward.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.HasDisabled, forward.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.IsDisabled, forward.Translate(Tilt.Right));

            // Backward
            var backward = TiltInto.PulseBy.Backward(new HysteresisThreshold(threshold));
            Assert.AreEqual(Pulse.IsDisabled, backward.Translate(Tilt.Forward));
            Assert.AreEqual(Pulse.HasEnabled, backward.Translate(Tilt.Backward));
            Assert.AreEqual(Pulse.IsEnabled, backward.Translate(Tilt.Backward));
            Assert.AreEqual(Pulse.HasDisabled, backward.Translate(Tilt.Left));
            Assert.AreEqual(Pulse.IsDisabled, backward.Translate(Tilt.Right));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PushBy.Distance(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PushBy.Left(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PushBy.Right(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PushBy.Forward(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PushBy.Backward(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PulseBy.Distance(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PulseBy.Left(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PulseBy.Right(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PulseBy.Forward(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = TiltInto.PulseBy.Backward(default);
            });
        }
    }
}
