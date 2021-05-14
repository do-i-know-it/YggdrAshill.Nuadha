using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(WhenPulseOf<>))]
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

            Assert.IsTrue(WhenPulseOf<Signal>.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasDisabled()
        {
            expected = Pulse.HasDisabled;

            Assert.IsFalse(WhenPulseOf<Signal>.IsDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf<Signal>.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseIsEnabled()
        {
            expected = Pulse.IsEnabled;

            Assert.IsFalse(WhenPulseOf<Signal>.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasDisabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf<Signal>.IsEnabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void ShouldDetectWhenPulseHasEnabled()
        {
            expected = Pulse.HasEnabled;

            Assert.IsFalse(WhenPulseOf<Signal>.IsDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.HasDisabled(this).Detect(new Signal()));
            Assert.IsFalse(WhenPulseOf<Signal>.IsEnabled(this).Detect(new Signal()));
            Assert.IsTrue(WhenPulseOf<Signal>.HasEnabled(this).Detect(new Signal()));
        }

        [Test]
        public void CannotBeGeneratetdWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf<Signal>.IsDisabled(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf<Signal>.HasDisabled(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf<Signal>.IsEnabled(null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var detection = WhenPulseOf<Signal>.HasEnabled(null);
            });
        }
    }
}
