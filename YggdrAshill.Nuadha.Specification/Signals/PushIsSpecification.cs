using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushIs))]
    internal class PushIsSpecification
    {
        [Test]
        public void ShouldBeSatisfiedWhenPushIsDisabled()
        {
            Assert.IsTrue(PushIs.Disabled.IsSatisfiedBy(Push.Disabled));
            Assert.IsFalse(PushIs.Disabled.IsSatisfiedBy(Push.Enabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPushIsEnabled()
        {
            Assert.IsFalse(PushIs.Enabled.IsSatisfiedBy(Push.Disabled));
            Assert.IsTrue(PushIs.Enabled.IsSatisfiedBy(Push.Enabled));
        }
    }
}
