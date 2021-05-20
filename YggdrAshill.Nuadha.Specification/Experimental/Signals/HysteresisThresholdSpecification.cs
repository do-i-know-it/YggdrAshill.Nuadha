using NUnit.Framework;
using YggdrAshill.Nuadha.Signals.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental.Specification
{
    [TestFixture(TestOf = typeof(HysteresisThreshold))]
    internal class HysteresisThresholdSpecification
    {
        [Test]
        public void CannotBeGeneratedWithNaNLowerLimit()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var threshold = new HysteresisThreshold(float.NaN, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithNaNUpperLimit()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var threshold = new HysteresisThreshold(0.0f, float.NaN);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLowerLimitLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var threshold = new HysteresisThreshold(-0.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithLowerLimitHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var threshold = new HysteresisThreshold(1.1f, 0.0f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithUpperLimitLowerThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var threshold = new HysteresisThreshold(0.0f, -0.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithUpperLimitHigherThanOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var threshold = new HysteresisThreshold(0.0f, 1.1f);
            });
        }

        [Test]
        public void CannotBeGeneratedWithUpperLimitLowerThanLowerLimit()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var threshold = new HysteresisThreshold(0.6f, 0.5f);
            });
        }
    }
}
