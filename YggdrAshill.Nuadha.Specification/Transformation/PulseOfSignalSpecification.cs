using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseOfSignal))]
    internal class PulseOfSignalSpecification :
        IConversion<Signal, Pulse>
    {
        private Pulse expected;

        public Pulse Convert(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected;
        }

        [Test]
        public void ShouldDetectWhenPulseIsDisabled()
        {
            expected = Pulse.IsDisabled;

            Assert.IsTrue(PulseOfSignal.Is.Disabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Disabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Is.Enabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Enabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            expected = Pulse.HasDisabled;

            Assert.IsTrue(PulseOfSignal.Is.Disabled(this).Detect(new Signal()));
            Assert.IsTrue(PulseOfSignal.Has.Disabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Is.Enabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Enabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            expected = Pulse.IsEnabled;

            Assert.IsFalse(PulseOfSignal.Is.Disabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Disabled(this).Detect(new Signal()));
            Assert.IsTrue(PulseOfSignal.Is.Enabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Enabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            expected = Pulse.HasEnabled;

            Assert.IsFalse(PulseOfSignal.Is.Disabled(this).Detect(new Signal()));
            Assert.IsFalse(PulseOfSignal.Has.Disabled(this).Detect(new Signal()));
            Assert.IsTrue(PulseOfSignal.Is.Enabled(this).Detect(new Signal()));
            Assert.IsTrue(PulseOfSignal.Has.Enabled(this).Detect(new Signal()));
        }

        [Test]
        public void CannotBeGeneratetdWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = PulseOfSignal.Is.Disabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = PulseOfSignal.Has.Disabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = PulseOfSignal.Is.Enabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = PulseOfSignal.Has.Enabled<Signal>(null);
            });
        }
    }
}
