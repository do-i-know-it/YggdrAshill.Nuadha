using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Touch))]
    internal class TouchSpecification
    {
        [Test]
        public void EnabledShouldBeEqualToEnabled()
        {
            Assert.IsTrue(Touch.Enabled == Touch.Enabled);
        }

        [Test]
        public void DisabledShouldBeEqualToDisabled()
        {
            Assert.IsTrue(Touch.Disabled == Touch.Disabled);
        }

        [Test]
        public void EnabledAndDisabledShouldNotBeEqual()
        {
            Assert.IsTrue(Touch.Enabled != Touch.Disabled);
        }
    }
}
