using NUnit.Framework;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Pull))]
    internal class PullSpecification
    {
        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldBeEqualToSameValue(float expected)
        {
            Assert.AreEqual(new Pull(expected), new Pull(expected));
        }

        [TestCase(1.0f, 0.0f)]
        [TestCase(0.5f, 1.0f)]
        [TestCase(0.0f, 0.5f)]
        public void ShouldNotBeEqualToSameValue(float one, float another)
        {
            Assert.AreNotEqual(new Pull(one), new Pull(another));
        }

        [Test]
        public void CannotBeGeneratedWithNaN()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Pull(float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithValueOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pull(-0.1f);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pull(1.1f);
            });
        }
    }
}
