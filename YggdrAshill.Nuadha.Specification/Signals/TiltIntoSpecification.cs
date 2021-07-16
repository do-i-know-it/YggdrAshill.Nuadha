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
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Distance.Convert(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Convert(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Convert(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Convert(Tilt.Upward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Distance.Convert(Tilt.Downward));

            // Left
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Convert(Tilt.Origin));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Left.Convert(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Convert(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Convert(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Left.Convert(Tilt.Downward));

            // Right
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Convert(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Convert(Tilt.Left));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Right.Convert(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Convert(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Right.Convert(Tilt.Downward));

            // Forward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Convert(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Convert(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Convert(Tilt.Right));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Forward.Convert(Tilt.Upward));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Forward.Convert(Tilt.Downward));

            // Backward
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Convert(Tilt.Origin));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Convert(Tilt.Left));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Convert(Tilt.Right));
            Assert.AreEqual(new Pull(0.0f), TiltInto.PullBy.Backward.Convert(Tilt.Upward));
            Assert.AreEqual(new Pull(1.0f), TiltInto.PullBy.Backward.Convert(Tilt.Downward));
        }

        [Test]
        public void ShouldConvertTiltIntoPush()
        {
            // Distance
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Convert(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Convert(Tilt.Left));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Convert(Tilt.Right));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Convert(Tilt.Upward));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Distance(new HysteresisThreshold()).Convert(Tilt.Downward));

            // Left
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Convert(Tilt.Origin));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Convert(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Convert(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Convert(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Left(new HysteresisThreshold()).Convert(Tilt.Downward));

            // Right
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Convert(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Convert(Tilt.Left));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Convert(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Convert(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Right(new HysteresisThreshold()).Convert(Tilt.Downward));

            // Forward
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Convert(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Convert(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Convert(Tilt.Right));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Convert(Tilt.Upward));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Forward(new HysteresisThreshold()).Convert(Tilt.Downward));

            // Left
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Convert(Tilt.Origin));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Convert(Tilt.Left));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Convert(Tilt.Right));
            Assert.AreEqual(Push.Disabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Convert(Tilt.Upward));
            Assert.AreEqual(Push.Enabled, TiltInto.PushBy.Backward(new HysteresisThreshold()).Convert(Tilt.Downward));
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
