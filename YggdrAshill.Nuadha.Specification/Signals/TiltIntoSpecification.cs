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
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Upward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Translate(Tilt.Downward));

            // Left
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Left.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Translate(Tilt.Downward));

            // Right
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Right.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Translate(Tilt.Downward));

            // Forward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Forward.Translate(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Translate(Tilt.Downward));

            // Backward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Translate(Tilt.Upward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Backward.Translate(Tilt.Downward));
        }

        [Test]
        public void ShouldConvertTiltIntoPush()
        {
            // Distance
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Translate(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Translate(Tilt.Left));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Translate(Tilt.Right));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Translate(Tilt.Upward));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Translate(Tilt.Downward));

            // Left
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Translate(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Translate(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Translate(Tilt.Downward));

            // Right
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Translate(Tilt.Left));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Translate(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Translate(Tilt.Downward));

            // Forward
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Translate(Tilt.Right));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Translate(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Translate(Tilt.Downward));

            // Left
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Translate(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Translate(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Translate(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Translate(Tilt.Upward));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Translate(Tilt.Downward));
        }

        [Test]
        [Ignore("Too many steps for test.")]
        public void ShouldConvertTiltIntoPulse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PushBy.Distance(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PushBy.Left(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PushBy.Right(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PushBy.Forward(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PushBy.Backward(default);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PulseBy.Distance(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PulseBy.Left(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PulseBy.Right(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PulseBy.Forward(default);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var conversion = TiltInto.PulseBy.Backward(default);
            });
        }
    }
}
