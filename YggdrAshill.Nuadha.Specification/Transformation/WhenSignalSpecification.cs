using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenSignal))]
    internal class WhenSignalSpecification :
        IPulsation<Signal>
    {
        private Pulse expected;

        public Pulse Pulsate(Signal signal)
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

            Assert.IsTrue(WhenSignal.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            expected = Pulse.HasDisabled;

            Assert.IsFalse(WhenSignal.IsDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenSignal.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            expected = Pulse.IsEnabled;

            Assert.IsFalse(WhenSignal.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenSignal.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            expected = Pulse.HasEnabled;

            Assert.IsFalse(WhenSignal.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenSignal.IsEnabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenSignal.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void CannotBeGeneratetdWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenSignal.IsDisabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenSignal.HasDisabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenSignal.IsEnabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenSignal.HasEnabled<Signal>(null);
            });
        }
    }
}
