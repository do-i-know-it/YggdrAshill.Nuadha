using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushIs))]
    internal class PushIsSpecification
    {
        [Test]
        public void ShouldDetectWhenPushIsDisabled()
        {
            Assert.IsTrue(PushIs.Disabled.Detect(Push.Disabled));
            Assert.IsFalse(PushIs.Disabled.Detect(Push.Enabled));
        }

        [Test]
        public void ShouldDetectWhenPushIsEnabled()
        {
            Assert.IsFalse(PushIs.Enabled.Detect(Push.Disabled));
            Assert.IsTrue(PushIs.Enabled.Detect(Push.Enabled));
        }
    }
}
