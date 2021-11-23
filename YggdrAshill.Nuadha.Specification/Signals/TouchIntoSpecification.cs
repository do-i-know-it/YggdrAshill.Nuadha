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
    }
}
