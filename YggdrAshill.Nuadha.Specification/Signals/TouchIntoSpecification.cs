using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(TouchInto))]
    internal class TouchIntoSpecification
    {
        [Test]
        public void ShouldConvertTouchIntoPush()
        {
            var translation = TouchInto.Push;

            Assert.AreEqual(Push.Disabled, translation.Translate(Touch.Disabled));

            Assert.AreEqual(Push.Enabled, translation.Translate(Touch.Enabled));
        }

        [Test]
        public void ShouldConvertTouchIntoPulse()
        {
            // When condition is generated, initial pulse is disabled.
            var translation = TouchInto.Pulse;

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Touch.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Touch.Enabled));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, translation.Translate(Touch.Enabled));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Touch.Disabled));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(Touch.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(Touch.Enabled));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(Touch.Disabled));
        }
    }
}
