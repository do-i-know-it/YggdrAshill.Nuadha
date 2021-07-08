using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Touch))]
    internal class TouchSpecification
    {
        [Test]
        public void ShouldBeEqualWhenTouchIsDisabled()
        {
            Assert.IsTrue(Touch.Disabled == Touch.Disabled);
            Assert.IsTrue(Touch.Disabled != Touch.Enabled);
        }

        [Test]
        public void ShouldBeEqualWhenTouchIsEnabled()
        {
            Assert.IsTrue(Touch.Enabled != Touch.Disabled);
            Assert.IsTrue(Touch.Enabled == Touch.Enabled);
        }
    }
}
