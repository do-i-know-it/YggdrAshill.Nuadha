using NUnit.Framework;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(PullInto))]
    internal class PullIntoSpecification
    {
        private const float Offset = 0.1f;

        private static Pull Under(float threshold)
        {
            return new Pull(threshold - Offset);
        }

        private static Pull Over(float threshold)
        {
            return new Pull(threshold + Offset);
        }

        [TestCase(0.8f)]
        [TestCase(0.5f)]
        [TestCase(0.2f)]
        public void ShouldConvertPullIntoPush(float threshold)
        {
            var translation = PullInto.Push(new HysteresisThreshold(threshold));

            Assert.AreEqual(Push.Disabled, translation.Translate(Under(threshold)));

            Assert.AreEqual(Push.Enabled, translation.Translate(Over(threshold)));
        }

        [Test]
        public void CannotBeGeneratedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var translation = PullInto.Push(default);
            });
        }
    }
}
