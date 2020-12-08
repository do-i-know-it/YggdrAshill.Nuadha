using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Push))]
    internal class PushSpecification
    {
        [Test]
        public void EnabledShouldBeEqualToEnabled()
        {
            Assert.IsTrue(Push.Enabled == Push.Enabled);
        }

        [Test]
        public void DisabledShouldBeEqualToDisabled()
        {
            Assert.IsTrue(Push.Disabled == Push.Disabled);
        }

        [Test]
        public void EnabledAndDisabledShouldNotBeEqual()
        {
            Assert.IsTrue(Push.Enabled != Push.Disabled);
        }
    }
}
