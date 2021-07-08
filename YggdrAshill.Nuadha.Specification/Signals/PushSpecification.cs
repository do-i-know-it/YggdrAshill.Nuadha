using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Push))]
    internal class PushSpecification
    {
        [Test]
        public void ShouldBeEqualWhenPushIsDisabled()
        {
            Assert.IsTrue(Push.Disabled == Push.Disabled);
            Assert.IsTrue(Push.Disabled != Push.Enabled);
        }

        [Test]
        public void ShouldBeEqualWhenPushIsEnabled()
        {
            Assert.IsTrue(Push.Enabled != Push.Disabled);
            Assert.IsTrue(Push.Enabled == Push.Enabled);
        }
    }
}