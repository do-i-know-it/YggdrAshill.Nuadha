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
        public void ShouldSignifyStrength(float expected)
        {
            Assert.AreEqual(expected, new Pull(expected).Strength);
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
        public void CannotBeGeneratedWithStrengthLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pull(-0.1f);
            });
        }
        
        [Test]
        public void CannotBeGeneratedWithStrengthHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Pull(1.1f);
            });
        }
    }
}
