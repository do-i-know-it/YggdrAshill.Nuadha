using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PushInto))]
    internal class PushIntoSpecification
    {
        [Test]
        public void ShouldConvertPushIntoTouch()
        {
            var translation = PushInto.Touch;

            Assert.AreEqual(Touch.Disabled, translation.Translate(Push.Disabled));

            Assert.AreEqual(Touch.Enabled, translation.Translate(Push.Enabled));
        }
    }
}
