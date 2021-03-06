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
            var conversion = TouchInto.Push;

            Assert.AreEqual(Push.Disabled, conversion.Convert(Touch.Disabled));

            Assert.AreEqual(Push.Enabled, conversion.Convert(Touch.Enabled));
        }

        [Test]
        public void ShouldConvertTouchIntoPulse()
        {
            // When condition is generated, initial pulse is disabled.
            var conversion = TouchInto.Pulse;

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Touch.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Touch.Enabled));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            Assert.AreEqual(Pulse.IsEnabled, conversion.Convert(Touch.Enabled));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Touch.Disabled));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            Assert.AreEqual(Pulse.IsDisabled, conversion.Convert(Touch.Disabled));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            Assert.AreEqual(Pulse.HasEnabled, conversion.Convert(Touch.Enabled));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            Assert.AreEqual(Pulse.HasDisabled, conversion.Convert(Touch.Disabled));
        }
    }
}
