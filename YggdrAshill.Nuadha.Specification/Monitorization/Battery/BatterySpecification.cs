using NUnit.Framework;
using YggdrAshill.Nuadha.Monitorization;
using System;

namespace YggdrAshill.Nuadha.Specification
{
    [TestFixture(TestOf = typeof(Battery))]
    internal class BatterySpecification
    {
        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldBeEqualToSameValue(float expected)
        {
            Assert.AreEqual(new Battery(expected), new Battery(expected));
            Assert.IsTrue(new Battery(expected) == new Battery(expected));
        }

        [TestCase(1.0f, 0.0f)]
        [TestCase(0.5f, 1.0f)]
        [TestCase(0.0f, 0.5f)]
        public void ShouldNotBeEqualToDiffrentOne(float one, float another)
        {
            Assert.AreNotEqual(new Battery(one), new Battery(another));
            Assert.IsTrue(new Battery(one) != new Battery(another));
        }

        [TestCase(1.0f)]
        [TestCase(0.5f)]
        [TestCase(0.0f)]
        public void ShouldBeConverted(float expected)
        {
            var signal = new Battery(expected);

            var converted = (float)signal;

            Assert.AreEqual(expected, converted);
        }

        [Test]
        public void CannotBeGeneratedWithNaNLevel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var signal = new Battery(float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLevelLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Battery(-0.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLevelHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var signal = new Battery(1.1f);
            });
        }
    }
}
