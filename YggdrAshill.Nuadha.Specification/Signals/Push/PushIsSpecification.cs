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
            Assert.IsTrue(PushIs.Disabled.Notify(Push.Disabled));
            Assert.IsFalse(PushIs.Disabled.Notify(Push.Enabled));
        }

        [Test]
        public void ShouldBeSatisfiedWhenPushIsEnabled()
        {
            Assert.IsFalse(PushIs.Enabled.Notify(Push.Disabled));
            Assert.IsTrue(PushIs.Enabled.Notify(Push.Enabled));
        }
    }
}
