using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(WhenPulseOf))]
    internal class WhenPulseOfSpecification :
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

            Assert.IsTrue(WhenPulseOf.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            expected = Pulse.HasDisabled;

            Assert.IsFalse(WhenPulseOf.IsDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            expected = Pulse.IsEnabled;

            Assert.IsFalse(WhenPulseOf.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            expected = Pulse.HasEnabled;

            Assert.IsFalse(WhenPulseOf.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf.IsEnabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void CannotBeGeneratetdWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf.IsDisabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf.HasDisabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf.IsEnabled<Signal>(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf.HasEnabled<Signal>(null);
            });
        }
    }
}
