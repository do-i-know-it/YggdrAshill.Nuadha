using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PulseFrom))]
    internal class PulseFromSpecification
    {
        [Test]
        public void ShouldTranslateSignalIntoPulse()
        {
            var condition = new SignalCondition();

            // When condition is generated, initial pulse is disabled.
            var translation = PulseFrom.Signal(condition);

            // When previous pulse is disabled and condition is not satisfied, current pulse is disabled.
            condition.Previous = false;
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(new Signal()));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            condition.Previous = true;
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(new Signal()));

            // When previous pulse has enabled and condition is satisfied, current pulse is enabled.
            condition.Previous = true;
            Assert.AreEqual(Pulse.IsEnabled, translation.Translate(new Signal()));

            // When previous pulse is enabled and condition is not satisfied, current pulse has disabled.
            condition.Previous = false;
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(new Signal()));

            // When previous pulse has disabled and condition is not satisfied, current pulse is disabled.
            condition.Previous = false;
            Assert.AreEqual(Pulse.IsDisabled, translation.Translate(new Signal()));

            // When previous pulse is disabled and condition is satisfied, current pulse has enabled.
            condition.Previous = true;
            Assert.AreEqual(Pulse.HasEnabled, translation.Translate(new Signal()));

            // When previous pulse has enabled and condition is not satisfied, current pulse has disabled.
            condition.Previous = false;
            Assert.AreEqual(Pulse.HasDisabled, translation.Translate(new Signal()));
        }
    }
}
